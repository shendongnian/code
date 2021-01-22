    public class MyBase
    {
        protected object PropertyOfBase { get; set; }
    }
    public class MyType : MyBase
    {
        void MyMethod()
        {
            object p =  base.PropertyOfBase;
        }
    }
