    public class IIdentityStub : IIdentity{
        private string _name;
        public IIdentityStub(string name){
            _name = name;
        }
    
        public string Name { get { return _name; } }
    }
