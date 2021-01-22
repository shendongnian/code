    public class CredentialsSection
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class configuration
    {
        /// <remarks/>
        public string logging { get; set; }
        /// <remarks/>
        [XmlElement("credentials")]
        public List<CredentialsSection> credentials { get; set; }
        public string Serialize()
        {
            var credentialsSection = new CredentialsSection {Username = "a", Password = "b"};
            this.credentials = new List<CredentialsSection> {credentialsSection, credentialsSection};
            this.logging = "log this";
            XmlSerializer s = new XmlSerializer(this.GetType());
            StringBuilder sb = new StringBuilder();
            TextWriter w = new StringWriter(sb);
            s.Serialize(w, this);
            w.Flush();
            return sb.ToString();
        }
    }
