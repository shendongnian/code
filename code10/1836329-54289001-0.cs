        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc[0] = "Test Name";
            mc[1] = "Test Surname";
        }
        class MyClass
        {
            public string this[int i]
            {
                set
                {
                    var props = this.GetType().GetProperties();
                    props[i + 1].SetValue(this, value);
                }
            }
            public string Name { get; private set; }
            public string Surname { get; private set; }
        }
