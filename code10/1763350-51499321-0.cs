    using System;
    using System.Threading.Tasks;
    using System.Threading.Channels;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace ConcurrentQueue
    {
        class Program
        {
            //Buffer for writing. After the capacity has been reached, a read must take place because the channel is full.
            private static readonly int Capacity = 10; 
    
            //Number of orders to write by each writer. (Choose 0 for infinitive.)
            private static readonly int NumberOfOrdersToWrite = 25;
    
            //Delay in ms used 
            private static readonly int Delay = 50;
    
            private static Dictionary<OrderTypeEnum, Aggregate> _aggregates;
    
            static void Main(string[] args)
            {
                //Prepare
                InitializeAggregates();
    
                MainAsync(args).GetAwaiter().GetResult();
            }
    
            static async Task MainAsync(string[] args)
            {
                var channel = Channel.CreateBounded<Order>(Capacity);
    
                var readerTask = Task.Run(() => ReadFromChannelAsync(channel.Reader));
    
                var writerTask01 = Task.Run(() => WriteToChannelAsync(channel.Writer, 1, NumberOfOrdersToWrite));
                var writerTask02 = Task.Run(() => WriteToChannelAsync(channel.Writer, 2, NumberOfOrdersToWrite));
                var writerTask03 = Task.Run(() => WriteToChannelAsync(channel.Writer, 3, NumberOfOrdersToWrite));
                var writerTask04 = Task.Run(() => WriteToChannelAsync(channel.Writer, 4, NumberOfOrdersToWrite));
    
                while (!writerTask01.IsCompleted || !writerTask02.IsCompleted || !writerTask03.IsCompleted || !writerTask04.IsCompleted)
                {
                }
    
                channel.Writer.Complete();
    
                await channel.Reader.Completion;
    
                ShowOutput();
            }
    
            public static async Task WriteToChannelAsync(ChannelWriter<Order> writer, int writerNumber, int numberOfOrdersToWrite = 0)
            {
                int i = 1;
                while (numberOfOrdersToWrite == 0 || i <= numberOfOrdersToWrite)
                {
                    
                    var order = CreateOrder(writerNumber, i);
                    await writer.WriteAsync(order);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: writer {writerNumber} just wrote order {order.OrderNumber} with value {order.OrderType}.");
                    i++;
                    //await Task.Delay(Delay);  //this simulates some work...
                }
            }
    
            private static async Task ReadFromChannelAsync(ChannelReader<Order> reader)
            {
                while (await reader.WaitToReadAsync())
                {
                    while (reader.TryRead(out Order order))
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: reader just read order {order.OrderNumber} with value {order.OrderType}.");
                        _aggregates[order.OrderType].Count++;
                        await Task.Delay(Delay);  //this simulates some work...
                    }
                }
            }
    
            private static void InitializeAggregates()
            {
                _aggregates = new Dictionary<OrderTypeEnum, Aggregate>();
                _aggregates[OrderTypeEnum.Type1] = new Aggregate();
                _aggregates[OrderTypeEnum.Type2] = new Aggregate();
                _aggregates[OrderTypeEnum.Type3] = new Aggregate();
            }
    
            private static Order CreateOrder(int writerNumber, int seq)
            {
                string orderNumber = $"{writerNumber}-{seq}";
                var order = new Order() { OrderNumber = orderNumber, OrderType = GetRandomOrderType() };
                return order;
            }
    
            private static OrderTypeEnum GetRandomOrderType()
            {
                Array values = Enum.GetValues(typeof(OrderTypeEnum));
                var random = new Random();
                return (OrderTypeEnum)values.GetValue(random.Next(values.Length));
            }
    
            private static void ShowOutput()
            {
                var total =
                    _aggregates[OrderTypeEnum.Type1].Count +
                    _aggregates[OrderTypeEnum.Type2].Count +
                    _aggregates[OrderTypeEnum.Type3].Count;
    
                Console.WriteLine();
                Console.WriteLine($"Type: {OrderTypeEnum.Type1} Count: {_aggregates[OrderTypeEnum.Type1].Count}");
                Console.WriteLine($"Type: {OrderTypeEnum.Type2} Count: {_aggregates[OrderTypeEnum.Type2].Count}");
                Console.WriteLine($"Type: {OrderTypeEnum.Type3} Count: {_aggregates[OrderTypeEnum.Type3].Count}");
                Console.WriteLine($"Total for all types: {total}");
                Console.WriteLine();
                Console.WriteLine("Done! Press a key to close the window.");
                Console.ReadKey();
            }
        }
    
        public class Order
        {
            public string OrderNumber { get; set; }
            public OrderTypeEnum OrderType { get; set; }
        }
    
        public class Aggregator
        {
            public void Aggregate(Order order, Dictionary<OrderTypeEnum, Aggregate> aggregates)
            {
                 aggregates[order.OrderType].Count++;
            }
        }
    
        public class Aggregate
        {
            public OrderTypeEnum OrderType { get; set; }
            public int Count { get; set; }
        }
    
        public enum OrderTypeEnum
        {
            Type1 = 1,
            Type2 = 2,
            Type3 = 3
        }
    }
