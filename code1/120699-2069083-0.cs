    class CreditCardBase : ICreditCard 
    {
        string Name { get; }
    }
    interface IWritableCreditCard : ICreditCard
    {
        string Name { get; set; }
    }
    class WritableCreditCard : CreditCardBase, IWritableCreditCard {}
    class Order
    {
        private ICreditCard _card = new WritableCreditCard(); //initially...
        public ICreditCard Card { get {return _card; } }
        void OnComplete(...) { _card = new CreditCardBase(copy from _card); }
    }
