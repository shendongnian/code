    public class MyObject : IComparable<MyObject>
    {
        public string Name { get; set; }
        public int? Number { get; set; }
    
        public int CompareTo(MyObject other)
        {
            return Comparer<int?>.Default.Compare(this.Number, other.Number);
        }
    }
