`
 public PaymentStateMachine()
        {
            InstanceState(x => x.CurrentState);
            
            this.ConfigureCorrelationIds();
.....
//Saga workflow registration
.....
            this.During(ValidationSucceeded
                , SetPaymentGatewaySubmissionHandler());            
            SetCompletedWhenFinalized();
        }
`
We had to register our initial event such that we saved some information off of the initial message into the saga table.  The key pieces to note are the *context.responseAddress* and *context.RequestId* being saved into the Saga Factory.
`
private void ConfigureCorrelationIds()
{
Event(() => PaymentSubmittedEvent,
                x =>
                {
                    x.CorrelateBy<int>(pay => pay.OrderId, context => context.Message.Order.Id)
                    .SelectId(c => c.Message.CorrelationId);
                    x.InsertOnInitial = true;
                    x.SetSagaFactory(context => new PaymentSagaState()
                    {
                        ResponseAddress = context.ResponseAddress.ToString(),
                        CorrelationId = context.CorrelationId.Value,
                        RequestId = context.RequestId,
                        OrderId = context.Message.Order.Id,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        CurrentState = Initial.Name
                    });
                });
....
//Other events registered
}
`
From there, we then used the answer marked above to send back the response to the original message's response address when we were done processing our saga.  The *new PaymentSubmittedResponse* is just a private implementation within the saga of our message contract that the client is waiting for on the front end.
`
private EventActivityBinder<PaymentSagaState, IPaymentGatewaySubmittedEvent> SetPaymentGatewaySubmissionHandler() =>
            When(PaymentGatewaySubmittedEvent)
                .Then(c => this.UpdateSagaState(c, PaymentGatewayComplete.Name))
                .Then(c => Console.Out.WriteLineAsync(
                    $"{DateTime.Now} PaymentGatewayComplete: {c.Data.Status} to {c.Instance.CorrelationId}"))
                .ThenAsync(async c =>
                {              
                    //Send response back to orignial requestor once we are done with this step               
                    var responseEndpoint =
                            await c.GetSendEndpoint(new Uri(c.Instance.ResponseAddress));
                    await responseEndpoint.Send(new PaymentSubmittedResponse(c.Data), callback: sendContext => sendContext.RequestId = c.Instance.RequestId);
                })
            .TransitionTo(ClientPaymentSubmissionResponded);
private void UpdateSagaState(BehaviorContext<PaymentSagaState> sagaContext, string status)
        {
            sagaContext.Instance.CurrentState = status;
            sagaContext.Instance.Updated = DateTime.Now;
        }
private class PaymentSubmittedResponse : IPaymentSubmittedEvent
        {
            public string Status { get; set; }
            public OrderDto Order { get; set; }
            public Guid CorrelationId { get; set; }
            public DateTime TimeStamp { get; set; }
            public PaymentSubmittedResponse(IPaymentBase paymentMessage)
            {
                Order = paymentMessage.Order;
                CorrelationId = paymentMessage.CorrelationId;
                Status = paymentMessage.Status;
                TimeStamp = paymentMessage.TimeStamp;
            }
        }
`
Not sure if it's entirely needed or if it's just due to how we implemented it, but we had to introduce one more saga state of *ClientPaymentSubmissionResponded* to handle the response message event being sent back to the original request.
