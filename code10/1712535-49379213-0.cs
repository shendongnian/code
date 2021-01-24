        public class MyConstants
        {
            //Gets compiled into user code. Changing value -> rebuild all clients.
            public const double BUYING_RATE = 0.5;
            //Gets evaluated in run-time. Changing value -> clients get new value.
            public readonly double BUYING_RATE = 0.5;
        }
