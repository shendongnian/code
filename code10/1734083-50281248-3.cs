    public partial class Observer: Form
    {
        private StockMarket stockMarket;
    
        public ConcreteObserverPull()
        {
           InitializeComponent();
           stockMarket = new StockMarket();
         //Here you cannot change the state
           stockMarket.Companies.Add(new Company(this.GetType(), "aa", "_", 123,12)); 
                                    
               
        }
        //...
    }
