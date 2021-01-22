    interface ISomeData {}
    class SomeActualData : ISomeData {}
    class SomeOtherData : ISomeData {}
    interface ISomeInterface
    {
        void DoSomething(ISomeData data);
    }
    class SomeImplementation : ISomeInterface
    {
        public void DoSomething(ISomeData data)
        {
            dynamic specificData = data;
            HandleThis( specificData );
        }
        private void HandleThis(SomeActualData data)
        { /* ... */ }
        private void HandleThis(SomeOtherData data)
        { /* ... */ }
    }
