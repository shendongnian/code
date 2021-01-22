    public partial class Offer
    {
        public static Expression<Func<Offer, bool>> exp 
        {
            get
            {
                return o => o.Property1 * o.Property2 == someValue; 
            }
        }
        public bool MyProperty
        {
            get 
            {
                return exp.Compile()(this);
            }
        }
    }
