    // Parent can Read
    public class Parent
    {
        public string Read(){ /*reads here*/ };
    }
    // Child need Info
    public class Child
    {
        private string information;
        // declare a Delegate
        delegate string GetInfo();
        // use a instance of the declared Delegate
        public GetInfo GetMeInformation;
        public void ObtainInfo()
        {
            // Child will use the Parent capabilities via the Delegate
            information = GetMeInformation();
        }
    }
