    [RunInstaller(true)]
    public class MySnapin : PSSnapIn
    {
        public override string Name { get { return "MyCommandlets"; } }
        public override string Vendor { get { return "MyCompany"; } }
        public override string Description { get { return "Does unnecessary aritmetic."; } }
    }
