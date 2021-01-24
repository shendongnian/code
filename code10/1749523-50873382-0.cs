    // I wasn't sure what the parameters were called or their type,
    // so I just used an int and string to demonstrate the functionality
    public class ChartValuesChangedEventArgs : EventArgs
    {
        public ChartValuesChangedEventArgs (int value1, string value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public int Value1 { get; private set; }
        public string Value2 { get; private set; }
    }
