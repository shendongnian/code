    class MockTypeABusinessLogic : ITypeABusinessLogic
    {
        public void DoBusinessLogic()
        {
            Console.WriteLine("[Mock] Do Business Logic for Type A");
        }
    }
    class MockTypeBBusinessLogic : ITypeBBusinessLogic
    {
        public void DoBusinessLogic()
        {
            Console.WriteLine("[Mock] Do Business Logic for Type B");
        }
    }
    class MockTypeAApplicationLogic : ITypeAApplicationLogic
    {
        public void DoApplicationLogic()
        {
            Console.WriteLine("[Mock] Do Application Logic for Type A");
        }
    }
    class MockTypeBApplicationLogic : ITypeBApplicationLogic
    {
        public void DoApplicationLogic()
        {
            Console.WriteLine("[Mock] Do Application Logic for Type B");
        }
    }
