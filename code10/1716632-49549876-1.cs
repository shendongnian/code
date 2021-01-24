    class Test {
        public event Action TestEvent
        {
            add { }
            remove { }
        }
        void Invoke() {
            // does not compile, invoke what?
            TestEvent();
        }
    }
