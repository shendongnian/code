        public void test1()
        {
            // Throw an exception for testing purposes
            throw new ArgumentException("test1");
        }
        void test2()
        {
                MethodInfo mi = typeof(Program).GetMethod("test1");
                ((Action)Delegate.CreateDelegate(typeof(Action), mi))();
        }
