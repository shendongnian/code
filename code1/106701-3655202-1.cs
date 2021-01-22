    public class Order
    {            
        private DateTime? _paidDate;
        private readonly Subject<Order> _paidSubj = new Subject<Order>();
        public IObservable<Order> Paid { get { return _paidSubj.AsObservable(); } }
        public void MarkPaid(DateTime paidDate)
        {
            _paidDate = paidDate;                
            _paidSubj.OnNext(this); // Raise PAID event
        }
    }
    private static void Main()
    {
        var order = new Order();
        order.Paid.Subscribe(_ => Console.WriteLine("Paid")); // Subscribe
        order.MarkPaid(DateTime.Now);
    }
