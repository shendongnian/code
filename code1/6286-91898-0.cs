    protected void Page_Load(object sender, EventArgs e)
    {
     XmlDocument config = new XmlDocument();
     config.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
     XmlNode node = config.SelectSingleNode("//configuration/system.web/authentication");
     this.Label1.Text = node.Attributes["mode"].Value;
    }
