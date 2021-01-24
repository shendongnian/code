        public class MyConstants
        {
            //Gets compiled into user code. Changing value -> rebuild all clients.
            //public const double BUYING_RATE = 0.5;
            //Gets evaluated in run-time. Changing value -> clients get new value.
            public readonly double BUYING_RATE = 0.5;
            private static MyConstants _default;
            static MyConstants()
            {
                _default = new MyConstants();
            }
            //Provide default instance. You can change it in run-time when needed.
            public static Default
            {
                get
                {
                    return _default;
                }
            }
        }
        private class User
        {
            public void Method1()
            {
                ... = MyConstants.Default.BUYING_RATE;
            }
        }
