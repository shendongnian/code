    var userName = userNameTextBox.Text;
    var password = passwordTextBox.Text;
    var match = System.Xml.Linq.XElement.Load(@"d:\users.xml")
        .Elements("user")
        .Where(x => x.Element("name")?.Value == userName &&
                    x.Element("password")?.Value == password)
        .Any();
