    public class Singleton
        {
            // Define a static variable to hold an instance of the class
            private static Singleton uniqueInstance;
    
            // Define a private constructor so that the outside world cannot create instances of the class
            private Singleton()
            {
            }
    
            /// <summary>
            /// Define public methods to provide a global access point, and you can also define public properties to provide global access points
            /// </summary>
            /// <returns></returns>
            public static Singleton GetInstance()
            {
                // Create if the instance of the class does not exist, otherwise return directly
                if (uniqueInstance == null)
                {
                    uniqueInstance = new Singleton();
                }
                return uniqueInstance;
            }
        }
