        class MyComparable : IComparable
    {
        public static int NumberOfComparisons = 0;
        public int NumPart { get; set; }
        #region IComparable Members
        public int CompareTo(object obj)
        {
            NumberOfComparisons++; //I know, not thread safe but just for the sample
            MyComparable mc = obj as MyComparable;
            if (mc == null)
                return -1;
            else
                return NumPart.CompareTo(mc.NumPart);
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MyComparable> list = new List<MyComparable>();
            list.Add(new MyComparable() { NumPart = 5 });
            list.Add(new MyComparable() { NumPart = 4 });
            list.Add(new MyComparable() { NumPart = 3 });
            list.Add(new MyComparable() { NumPart = 2 });
            list.Add(new MyComparable() { NumPart = 1 });
            list.Sort();
            
            Console.WriteLine(MyComparable.NumberOfComparisons);
        }
    }
