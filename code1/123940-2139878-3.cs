    // Parent can Read
    public class Parent
    {
        public string Read();
    }
    // Child need Info
    public class Child
    {
        private string information;
        delegate string GetInfo();
        public GetInfo GetMeInformation;
        public void ObtainInfo()
        {
            information = GetMeInformation();
        }
    }
