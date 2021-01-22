    public class SomeClassThatNeedsClientScriptManager {
        private IClientScriptManager _iClientScriptManager;
        public IClientScriptManager IClientScriptManager {
            get {
                if (_iClientScriptManager == null) {
                    _iClientScriptManager = new ClientScriptManagerWrapper(Page.ClientScriptManager);
                }
                return _iClientScriptManager;
            }
            set {
                _iClientScriptManager = value;
            }
        }
        public void SomeMethodThatUsesClientScriptManager() {
            IClientScriptManager.RegisterClientScriptBlock(typeof(Whatever), "key", "alert('hello')");
        }
    }
    public interface IClientScriptManager {
        void RegisterClientScriptBlock(Type type, string key, string script);
    }
    public class ClientScriptManagerWrapper : IClientScriptManager {
        private readonly ClientScriptManager _clientScriptManager;
        public ClientScriptManagerWrapper(ClientScriptManager clientScriptManager) {
            if (clientScriptManager == null) {
                throw new ArgumentNullException("clientScriptManager");
            }
            _clientScriptManager = clientScriptManager;
        }
        public void RegisterClientScriptBlock(Type type, string key, string script) {
            _clientScriptManager.RegisterClientScriptBlock(type, key, script);
        }
    }
