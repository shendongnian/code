    public class CamelClient : ICamelClient
    {
        //...
    
        private Contacts _contacts;
    
        public Contacts Contacts
        {
            get
            {
                if(_contacts == null)
                {
                    _contacts = new Contacts(_BaseAddress, _TokenEndpoint, _ClientId, _Secret);
                }
                return _contacts;
            }
        }
