    public class baseClass
    {
        public bool b = true;
        public void test()
        {
            if(!b)
            {
                BitThatNeedsToChange();
                return;
            }
        }
        protected virtual void BitThatNeedsToChange()
        {
            Console.WriteLine("b is true returning");
        }
    }
