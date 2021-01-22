    public class Class1
    {
        // prefix private fields with "m"
        private int mValue1;
        public int Value1
        {
            get { return mValue1; }
            set { mValue1 = value; }
        }
        private string mValue2;
        public string Value2
        {
            get { return mValue2; }
            set { mValue2 = value; }
        }
        // prefix parameters with "p"
        public bool PerformAction(int pValue1, string pValue2)
        {
            if (pValue1 > mValue1)
            {
                mValue2 = pValue2;
                return true;
            }
            else
            {
                return (mValue2 == pValue2);
            }
        }
    }
