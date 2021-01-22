    [ActiveRecord(Table = "MyTable")]
    public class MyClass : ActiveRecordBase<MyClass>
    {
        [Property]
        public int Id { get; set; }
        [Property]
        public int MyClassId { get; set; }
        [Property]
        public string ListItem { get; set; }
    }
