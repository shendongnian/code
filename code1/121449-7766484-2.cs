     public static int Method1(string mystring)
           {
               return 1;
           }
    
            public static int Method2(string mystring)
         {
           return 2;
         }
         
     public bool RunTheMethod(Action myMethodName)
            {
                myMethodName();
                return true;
            }
