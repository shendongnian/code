    class A {}
    class P
    {
        public static void Main()
        {
            A objA = new A(); 
            object obj = (object)objA; 
            bool b = obj.GetType() == typeof(object) ; // this is true
        }
    }
