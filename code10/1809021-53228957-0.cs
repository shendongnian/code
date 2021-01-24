    public static void DoSomething(IDoSomething MyObject)
    {
        MyObject.DoSomeMethod();
     }
     interface IDoSomething
     {
        void DoSomeMethod();
     }
     public class Class1 : IDoSomething
     {
        public int CustomerID;
        public int DriverID;
        public int EmployeeID;
    
         public void DoSomeMethod()
         {
                throw new NotImplementedException();
         }
     }
    
     public class Class2 : IDoSomething
     {
        public int CustomerID;
        public int DriverID;
        public int EmployeeID;
    
        public void DoSomeMethod()
        {
          throw new NotImplementedException();
        }
     }
