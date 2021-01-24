    public static class MyExtensionMethods
    {
        public static CheckSomething(this IInterface i, string arg) // option 1
        {
            switch (i)
            {
                 case i is Class1 class1:
                      // class specific implementation (maybe in a separate method)
                 ...
            }
        }
    }
