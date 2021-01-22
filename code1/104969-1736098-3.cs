    using System.ComponentModel;
    class Test
    {
        public int Bar { get; set; }
        static void Main()
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(
                typeof(Test))["Bar"];
            Test t = new Test();
            t.Bar = 123;
            object val = prop.GetValue(t);
        }
    }
