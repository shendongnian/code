    public Form1()
    {
        InitializeComponent();
        Person x = new Person();
        propertyGrid1.SelectedObject = x;
    }
    public class Person
    {
        public string Caption { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override string ToString()
            {
                return LastName + ", " + FirstName;
            }
        }
        private Name _name = new Name();
        public Name testName
        {
            get { return _name; }
        }
    }
