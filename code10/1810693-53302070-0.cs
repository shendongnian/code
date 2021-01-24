       public class MyClass
        {
            private string myString { get; set; }
            public int MyInt
            {
                get { return int.Parse(myString); }
                set { myString = value.ToString(); }
            }
        }
