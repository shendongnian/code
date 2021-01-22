    public class Stock
    {
        //declare a delegate for the event
        public delegate void AskPriceChangedHandler(object sender,
              AskPriceChangedEventArgs e);
        //declare the event using the delegate
        public event AskPriceChangedHandler AskPriceChanged;
        //instance variable for ask price
        object _askPrice;
        //property for ask price
        public object AskPrice
        {
            set
            {
                //set the instance variable
                _askPrice = value;
                //fire the event
                OnAskPriceChanged();
            }
        }//AskPrice property
        //method to fire event delegate with proper name
        protected void OnAskPriceChanged()
        {
            AskPriceChanged(this, new AskPriceChangedEventArgs(_askPrice));
        }//AskPriceChanged
    }//Stock class
    //specialized event class for the askpricechanged event
    public class AskPriceChangedEventArgs : EventArgs
    {
        //instance variable to store the ask price
        private object _askPrice;
        //constructor that sets askprice
        public AskPriceChangedEventArgs(object askPrice) { _askPrice = askPrice; }
        //public property for the ask price
        public object AskPrice { get { return _askPrice; } }
    }//AskPriceChangedEventArgs
