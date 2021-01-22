    internal class Program
    {
        private static void Main(string[] args)
        {
            var mock = new Mock<IData>();
            mock.Setup(d => d.InsertInvoice(It.IsAny<Invoice>()));
            var service = new MyService(mock.Object);
            service.DoSomething(new Invoice());
            mock.Verify(d => d.InsertInvoice(It.Is<Invoice>(i => i.TermPaymentAmount == 0m)), Times.Once());
            Console.ReadLine();
        }
    }
    internal class MyService
    {
        private readonly IData _data;
        public MyService(IData data)
        {
            _data = data;
        }
        public void DoSomething(Invoice invoice)
        {
            _data.InsertInvoice(invoice);
        }
    }
    public class Invoice
    {
        public decimal TermPaymentAmount { get; set; }
    }
    public interface IData
    {
        void InsertInvoice(Invoice invoice);
    }
