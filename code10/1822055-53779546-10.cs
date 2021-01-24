    public static Person ReadXml(string path)
    {
        Person person = new Person();
        using (XmlReader reader = XmlReader.Create(path))
        {
            while (reader.Read())
            {
                if (reader.Name == "attr" && reader.GetAttribute("n") == "id")
                    person.Id = Convert.ToInt32(reader.ReadInnerXml());
                if (reader.Name == "attr" && reader.GetAttribute("n") == "name")
                    person.Name = reader.ReadInnerXml();
                if (reader.Name == "attr" && reader.GetAttribute("n") == "street")
                    person.Address = new Address { Street = reader.ReadInnerXml() };
            }
        }
        return person;
    }
