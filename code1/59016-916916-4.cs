    public class MyType : IComparable<MyType>, IComparable
    {
        public MyType(string name, int id)
        { Name = name; Id = id; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int CompareTo(MyType other)
        {
            if (null == other)
                throw new ArgumentNullException("other");
            return (Id - other.Id > 0 ? 1 : 0);
        }
        public int CompareTo(object other)
        {
            if (null == other)
                throw new ArgumentNullException("other");
            if (other is MyType)
                return (Id - (other as MyType).Id > 0 ? 1 : 0);
            else
                throw new InvalidOperationException("Bad type");
        }
    }
    MyType t1 = new MyType("a", 1);
    MyType t2 = new MyType("b", 2);
    object someObj = new object();
    // calls the strongly typed method: CompareTo(MyType other)
    t1.CompareTo(t2);
    // calls the *weakly* typed method: CompareTo(object other)
    t1.CompareTo(someObj);
