    for (int i = 0; i < attributes.Count; i++)
    {
        if (attributes[i].getName() == "Owner")
        {
           string value = attributes[i].getValue();
           value = value.Replace(domain, "");
           user = value;
           UserExists(value);
        }
    }
