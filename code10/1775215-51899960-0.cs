    foreach (XmlNode node in list)
    {
        firstname = node.SelectSingleNode("FirstName").InnerText;
        lastname = node.SelectSingleNode("LastName").InnerText;
        SubmitToDatabase(firstname, lastname);
    }
