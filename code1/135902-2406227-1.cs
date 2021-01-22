    public class MyCredentialsExtensionElement : ClientCredentialsElement
    {
        protected override object CreateBehavior()
        {
            return new MyCredentials();
        }
        public override Type BehaviorType
        {
            get { return typeof(MyCredentials); }
        }
        // Snip other overrides like Properties
    }
