    class YourClass
    {
        static int Count = 0;
    
        public YourClass()
        {
           Count++;
           if(Count > 10)
           {
               //throw exception
           }
        }
    }
