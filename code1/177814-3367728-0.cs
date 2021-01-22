    public partial class Offer
    {
        public static Func<Offer, bool> MyFunc = o => 
        {
            // return true or false
        };
        public bool MyProperty
        {
            get 
            {
                return MyFunc(this);
            }
        }
    }
