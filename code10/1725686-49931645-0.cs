    public interface IOrderProcessor
    {
        void ProcessOrder(IOrder order);
    }
    public interface IOrder
    {
        void FinalizeSelf(IOrderProcessor oProc);
        int CustomerId {get; set;}
    }
    public class Customer
    {
        List<IOrder> _orders;
        IOrderProcessor _oProc;
        int _id;
        public Customer(IOrderProcessor oProc, int CustId)
        {
            _oProc = oProc;
            _orders = new List<IOrder>();
            _id = CustId;
        }
        public void CreateNewOrder()
        {
            IOrder _order = new Order() { CustomerId = _id };
            _order.FinalizeSelf(_oProc);
            _orders.Add(_order);
        }
        private class Order : IOrder
        {
            public int CustomerId {get; set;}
            public void FinalizeSelf(IOrderProcessor oProcessor)
            {
                oProcessor.ProcessOrder(this);
            }
        }
    }
    public class ConcreteProcessor : IOrderProcessor
    {
        public void ProcessOrder(IOrder order)
        {
            //Do something
        }
    }
