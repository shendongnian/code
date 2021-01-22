        // e.g. my test to create a file
        using (var writer = new FileStream("users.xml", FileMode.Create))
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<User>),  
                new XmlRootAttribute("user_list"));
            List<User> list = new List<User>();
            list.Add(new User { Id = 1, Name = "Joe" });
            list.Add(new User { Id = 2, Name = "John" });
            list.Add(new User { Id = 3, Name = "June" });
            ser.Serialize(writer, list);
        }
...  
        // read file
        List<User> users;
        using (var reader = new StreamReader("users.xml"))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<User>),  
                new XmlRootAttribute("user_list"));
            users = (List<User>)deserializer.Deserialize(reader);
        }
