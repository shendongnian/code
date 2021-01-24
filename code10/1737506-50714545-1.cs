    using InterpreterStateMachine.Contracts;
    using MassTransit;
    using MassTransit.QuartzIntegration;
    using MassTransit.RabbitMqTransport;
    using Quartz;
    using Quartz.Impl;
    using System;
    using System.Threading.Tasks;
    using Topshelf;
    namespace InterpreterStateMachine.Validator
    {
        public class ValidationService : ServiceControl
        {
            readonly IScheduler _scheduler;
            static IBusControl _busControl;
            BusHandle _busHandle;        
            public static IBus Bus => _busControl;
            public ValidationService()
            {
                _scheduler = CreateScheduler();
            }
            
            public bool Start(HostControl hostControl)
            {
                Console.WriteLine("Creating bus...");
                _busControl = MassTransit.Bus.Factory.CreateUsingRabbitMq(x =>
                {
                    IRabbitMqHost host = x.Host(new Uri(/*rabbitMQ server*/), h =>
                    {
                        /*credentials*/
                    });
                    x.UseInMemoryScheduler();
                    x.UseMessageScheduler(new Uri(RabbitMqServerAddress));
                    x.ReceiveEndpoint(host, "validation_needed", e =>
                    {
                        e.PrefetchCount = 1;
                        e.Durable = true;
                        //again this is how the consumer is registered
                        e.Consumer<RequestConsumer>();
                    });                               
                });
                
                Console.WriteLine("Starting bus...");
                
                try
                {
                    _busHandle = MassTransit.Util.TaskUtil.Await<BusHandle>(() => _busControl.StartAsync());
                    _scheduler.JobFactory = new MassTransitJobFactory(_busControl);
                    _scheduler.Start();
                }
                catch (Exception)
                {
                    _scheduler.Shutdown();
                    throw;
                }                
                return true;
            }
            public bool Stop(HostControl hostControl)
            {
                Console.WriteLine("Stopping bus...");
                _scheduler.Standby();
                _busHandle?.Stop();
                _scheduler.Shutdown();
                return true;
            }
            static IScheduler CreateScheduler()
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                IScheduler scheduler = MassTransit.Util.TaskUtil.Await<IScheduler>(() => schedulerFactory.GetScheduler());
                return scheduler;
            }
        }
        //again here comes the actual consumer logic, look how the message is re-published after it was checked
        class RequestConsumer : IConsumer<IValidationNeeded>
        {
            public async Task Consume(ConsumeContext<IValidationNeeded> context)
            {
                await Console.Out.WriteLineAsync($"(c) Received {context.Message.Request.RequestString} for validation (Id: {context.Message.RequestId}).");
                context.Message.Request.IsValid = context.Message.Request.RequestString.Contains("=");
                
                //send the new message on the "old" context
                await context.Publish<IValidating>(new
                {
                    Request = context.Message.Request,
                    IsValid = context.Message.Request.IsValid,
                    TimeStamp = DateTime.UtcNow,
                    RequestId = context.Message.RequestId
                });
            }
        }
    }
