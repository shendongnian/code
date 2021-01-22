    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
                                    {
                                        "Value1, 2010-06-28 10:30:00.000",
                                        "Value2, 2010-06-27 10:30:00.000",
                                        "Value3, 2010-06-26 10:30:00.000"
                                    };
    
            list.Sort(new MyComparer());
        }
    }
    
    internal class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xItems = x.Split(new []{','});
            var yItems = y.Split(new []{','});
            var xDateTime = DateTime.Parse(xItems[1]);
            var yDateTime = DateTime.Parse(yItems[1]);
            return xDateTime.CompareTo(yDateTime);
        }
    }
