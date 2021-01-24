    public class Globals
    {
        private static Globals _obj;
        public static Globals Current {
            get {
                if (_obj == null)
                    _obj = new Globals();
                return _obj;
            }
        }
        private Globals() { }
        private string _username;
        public string UserName { get { return _username; } }
        public void SetUserName(string userName) {
            this._username = userName;
        }
    }
