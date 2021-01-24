    public struct Data
    {
        public Data(int intValue)
        {
            IntData = intValue;
        }
        public int IntData { get; private set; }  
    }
    var list = new List<Data>();
    list.Add(new Data(123));
