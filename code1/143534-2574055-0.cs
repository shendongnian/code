    public class SodaConsumer
    {
        private readonly ISodaFactory sodaFactory;
        public SodaConsumer(ISodaFactory sodaFactory)
        {
            if (sodaFactory == null)
            {
                throw new ArgumentNullException(sodaFactory);
            }
            this.sodaFactory = sodaFactory;
        }
        public void DrinkSoda(string input)   
        {   
            ISoda soda = GetSoda(input);   
            soda.Drink();   
        }
        private ISoda GetSoda(input)
        {
            return this.sodaFactory.Create(input);
        }
    }
