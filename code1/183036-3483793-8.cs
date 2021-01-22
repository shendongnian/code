    namespace ConsoleApplication2
    {
        class Program
        {
            class Car
            {
                private int _speed;  
                public int Speed     // <-- no semicolon here.
                {
                    get
                    {
                        return _speed;  // <-- here
                    }
                }
            }
        }
    }
