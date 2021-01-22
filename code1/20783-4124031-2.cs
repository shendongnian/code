    [ClassInterface(ClassInterfaceType.None)]
    public class TestRequest : CustomDispatch, IRequest {
        private IRequestDictionary _queryString = new RequestDictionary();
    
        public IRequestDictionary QueryString {
            get { return _queryString; }
        }
    }
