        using InterpreterStateMachine.Contracts;
        using MassTransit;
        using System;
        using System.Threading.Tasks;
        namespace InterpreterStateMachine.Requester
        {
            class Program
            {
                private static IBusControl _busControl;
                static void Main(string[] args)
                {            
                    var busControl = ConfigureBus();
                    busControl.Start();
        
                    Console.WriteLine("Enter request or quit to exit: ");
                    while (true)
                    {
                        Console.Write("> ");
                        String value = Console.ReadLine();
                        if ("quit".Equals(value,StringComparison.OrdinalIgnoreCase))
                            break;
                        if (value != null)
                        {
                            String[] values = value.Split(';');
                            foreach (String v in values)
                            {
                                busControl.Publish<IRequesting>(new
                                {
                                    Request = new Request(v),
                                    TimeStamp = DateTime.UtcNow
                                });
                            }
                        }
                    }
                    busControl.Stop();
                }
                static IBusControl ConfigureBus()
                {
                    if (null == _busControl)
                    {
                        _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                        {                    
                            var host = cfg.Host(new Uri(/*rabbitMQ server*/), h =>
                            {                        
                                /*credentials*/
                            });
                    
                            cfg.ReceiveEndpoint(host, "answer_ready", e =>
                            {
                                e.Durable = true;
                                //here the consumer is registered
                                e.Consumer<AnswerConsumer>();
                            });
                        });
                        _busControl.Start();
                    }
                    return _busControl;
                }
                
                //here comes the actual logic of the consumer, which consumes a "contract"
                class AnswerConsumer : IConsumer<IAnswerReady>
                {
                    public async Task Consume(ConsumeContext<IAnswerReady> context)
                    {
                        await Console.Out.WriteLineAsync($"\nReceived Answer for \"{context.Message.Request.RequestString}\": {context.Message.Answer}.");
                        await Console.Out.WriteAsync(">");
                    }
                }        
            }
        }
