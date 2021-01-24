        private class LockExample
        {
            private readonly object lockObject = new object();
            public void TestLock()
            {
                lock(lockObject)
                {
                    //Do something
                }
            }
        }
        private class LockTest
        {
            public void Test()
            {
                var example = new LockExample();
                var lockOjbect = typeof(LockExample).GetField("lockObject", BindingFlags.NonPublic|BindingFlags.Instance).GetValue(example);
                lock (lockOjbect)
                {
                    var task = Task.Run((Action)example.TestLock);
                    task.Wait(1);   //allow the other thread to run
                }
            }
        }
