    public class thingThatHasNumericValue
    {
        private object arbNumber;
        public object SomeArbitraryNumber
        {
            get { return arbNumber; }
            set
            {
                if (!arbNumber.IsNumber())
                {
                    throw new InvalidOperationException("Must be a number");
                }
                arbNumber = value;
            }
        }
    }
