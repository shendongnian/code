    class CountEventArgs : EventArgs
    {
        public int CountValue { get; private set; }
        public CountEventArgs (int countValue)
        {
            CountValue = countValue;
        }
    }
    class SomeOtherClass
    {
        public event EventHandler<CountEventArgs> CountValueChanged;
        public void CountUp()
        {
            int CountValue;
            for (int i = 0; i < 100000000; i++)
            {
                CountValue = i;
                OnCountValueChanged(new CountEventArgs(CountValue));
            }
        }
        private void OnCountValueChanged(CountEventArgs e)
        {
            EventHandler<CountEventArgs> temp = CountValueChanged;
            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
