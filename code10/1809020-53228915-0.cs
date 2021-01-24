        public static  void DoSomething(object MyObject)
        {
            if (MyObject.GetType() == typeof(Class1))
            {
                //   (MyObject as Class1 )
            }
            if (MyObject.GetType() == typeof(Class2))
            {
                //   (MyObject as Class2 )
            }
        }
