    class Test {
        public event Action TestEvent;
        void Invoke() {
            // fine
            TestEvent();
        }
    }
