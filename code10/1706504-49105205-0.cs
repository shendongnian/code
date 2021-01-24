    class MyClass
    {
        public int RowNo { get; set; }
        public int Value { get; set; }
    }
    var List1 = new List<MyClass>()
    {
        new MyClass(){RowNo = 1, Value = 11},
        new MyClass(){RowNo = 2, Value = 22},
        new MyClass(){RowNo = 3, Value = 33},
        new MyClass(){RowNo = 4, Value = 88},
    };
    var List2 = new List<MyClass>()
    {
        new MyClass(){RowNo = 1, Value = 44},
        new MyClass(){RowNo = 2, Value = 55},
        new MyClass(){RowNo = 3, Value = 66}
    };
    List1.ForEach(l1 => l1.Value = (List2.FirstOrDefault(l2 => l2.RowNo == l1.RowNo) ?? l1).Value);
