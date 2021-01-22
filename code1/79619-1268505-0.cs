    class Blah
    {
        private static StringBuild container = new StringBuilder();
    
        private static ModifyString modifyString = new ModifyString();
    
        static void Main(...)
        {
        container.Append(Read From File(Kind of long));
        Thread thread1 = new Thread(Function1);
            Thread thread2 = new Thread(Function2);
        thread1.Start();
        thread2.Start();
        //Print out container
        }
    
        static void Function1
        {       
    
            //Do calculation and stuff to get the Array for the foreach
            foreach (.......Long loop........)
            {
               modifyString.Do("this", "With this")
           }
        }
        //Same goes for function but replacing different things.
        static void Function2
        {
            //Do calculation and stuff to get the Array for the foreach
            foreach (.......Long loop........)
            {
                modifyString.Do("this", "With this")
            }
        }
    }
