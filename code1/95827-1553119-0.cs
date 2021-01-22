    class Test {
        private static object Lock = new object();
        public function Synchronized()
        {
            lock(Lock)
            {
                // Only one thread at a time is able to enter this section
            }
        }
    }
