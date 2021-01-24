    using MassTransit;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Trabalhos.EventsEngine.Messages;
    
    namespace Trabalhos.EventsEngine.ClientExample
    {
        public class SenderHostedService : IHostedService
        {
            private readonly IBusControl eventsEngine;
            private readonly ILogger<SenderHostedService> logger;
    
            public SenderHostedService(IBusControl eventsEngine, ILogger<SenderHostedService> logger)
            {
                this.eventsEngine = eventsEngine;
                this.logger = logger;
            }
    
            public async Task StartAsync(CancellationToken cancellationToken)
            {
                var products = new List<(string name, decimal price)>();
    
                Console.WriteLine("Welcome to the Shop");
                Console.WriteLine("Press Q key to exit");
                Console.WriteLine("Press [0..9] key to order some products");
                Console.WriteLine(string.Join(Environment.NewLine, Products.Select((x, i) => $"[{i}]: {x.name} @ {x.price:C}")));
                for (;;)
                {
                    var consoleKeyInfo = Console.ReadKey(true);
                    if (consoleKeyInfo.Key == ConsoleKey.Q)
                    {
                        break;
                    }
    
                    if (char.IsNumber(consoleKeyInfo.KeyChar))
                    {
                        var product = Products[(int)char.GetNumericValue(consoleKeyInfo.KeyChar)];
                        products.Add(product);
                        Console.WriteLine($"Added {product.name}");
                    }
    
                    if (consoleKeyInfo.Key == ConsoleKey.Enter)
                    {
                        await eventsEngine.Publish<IDummyRequest>(new
                        {
                            requestedData = products.Select(x => new { Name = x.name, Price = x.price }).ToList()
                        });
    
                        Console.WriteLine("Submitted Order");
    
                        products.Clear();
                    }
                }
            }
    
            public Task StopAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
    
            private static readonly IReadOnlyList<(string name, decimal price)> Products = new List<(string, decimal)>
            {
                ("Bread", 1.20m),
                ("Milk", 0.50m),
                ("Rice", 1m),
                ("Buttons", 0.9m),
                ("Pasta", 0.9m),
                ("Cereals", 1.6m),
                ("Chocolate", 2m),
                ("Noodles", 1m),
                ("Pie", 1m),
                ("Sandwich", 1m),
            };
        }
    }
