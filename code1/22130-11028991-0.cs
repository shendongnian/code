    class MyBase
    {
        protected object PropertyOfBase { get; set; }
        protected static object GetPropertyOfBaseOf(MyBase obj) 
        {
            return obj.PropertyOfBase;
        }
    }
    class MyType : MyBase
    {
        void MyMethod(MyBase parameter)
        {
            object p = GetPropertyOfBaseOf(parameter);
        }
    }
