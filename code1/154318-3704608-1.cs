    protected void Page_Load(object sender, EventArgs e)
    {
        XDocument doc = XDocument.Load(Server.MapPath("~/XMLFile1.xml"));
        foreach (XElement initial in doc.XPathSelectElements("//given-names"))
        {
            string v = initial.Value.Replace(".", ". ").TrimEnd(' ');
            initial.SetValue(v);
        }
        string result = doc.ToString();
        Form.Controls.Add(new LiteralControl(String.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(result))));
    }
