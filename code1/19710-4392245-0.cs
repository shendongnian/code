class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            ExecutionReport er = new ExecutionReport("ORDID1234",3000.43,DateTime.UtcNow);
            Order ord = new Order();
            ord = er;
            Console.WriteLine("Transferred values are : " + er.OrderId + "\t" + ord.Amount.ToString() + "\t" + ord.TimeStamp.ToString() + "\t");
            Console.ReadLine();
        }
    }
    public  class Order
    {
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public static implicit operator ExecutionReport(Order ord)
        {
            return new ExecutionReport()
            {
                OrderId = ord.OrderId,
                Amount = ord.Amount,
                TimeStamp = ord.TimeStamp
            };
        }
        public static implicit operator Order(ExecutionReport er)
        {
            return new Order()
            {
                OrderId = er.OrderId,
                Amount = er.Amount,
                TimeStamp = er.TimeStamp
            };
        }
        public Order()
        { }
    }
    public  class ExecutionReport
    {
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public ExecutionReport() { }
        public ExecutionReport(string orderId,double amount, DateTime ts)
        {
            OrderId = orderId; Amount = amount; TimeStamp = ts;
        }
    }
