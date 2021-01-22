    public class MyListObject<T> : BindingList<T>
    {
        public MyListObject() { }
        public MyListObject(IList<T> list) : base(list) { }
    }
    // ...
    MyListObject<int> yourList = new MyListObject<int> { 1, 2, 3, 4, 5 };
    yourList = new MyListObject<int>(yourList.Select(s => s * 2).ToList());
    -- yourList now contains 2, 4, 6, 8, 10
