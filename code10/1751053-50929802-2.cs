    public class Model
    {
        public MyClass MyClass { get; set; }
        public Model()
        {
            //MyClass = myClass;
        }
        public Model(MyClass myClass)
        {
            MyClass = myClass;
        }
    }
