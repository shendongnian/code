    public class UserNamePasswordHeader : MessageHeader
    {
        private readonly string _serviceUserEmail;
        private readonly string _serviceUserPassword;
        public UserNamePasswordHeader(string serviceUserEmail, string serviceUserPassword)
        {
            this._serviceUserEmail = serviceUserEmail;
            this._serviceUserPassword = serviceUserPassword;
        }
        public override string Name
        {
            get { return "UserNameHeader"; }
        }
        public override string Namespace
        {
            get { return "urn:bar:services"; }
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString("UserName", _serviceUserEmail);
            writer.WriteElementString("Password", _serviceUserPassword);
        }
    }
