    [RunInstaller(true)]
    public class HashSnapin : PSSnapIn
    {
        public override string Name { get { return "MyCommandlets"; } }
        public override string Vendor { get { return "MyCompany"; } }
        public override string Description { get { return "Does unnecessary aritmetic."; } }
    }
