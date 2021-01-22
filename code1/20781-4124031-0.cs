        [ClassInterface(ClassInterfaceType.None)]
        [IDispatchImpl(IDispatchImplType.CompatibleImpl)]
        public class TestRequest : IRequest
        {
            private IRequestDictionary _queryString = new RequestDictionary();
            public IRequestDictionary QueryString
            {
                get { return _queryString; }
            }
        }
