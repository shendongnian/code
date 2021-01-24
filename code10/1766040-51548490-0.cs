    public struct DatabaseNode
        {
            public string Username;
            public string Name;
            public string Lastname;
            public Dictionary<string,string> Phones;
    
            public DatabaseNode(string user,string name,string lastname,string housephone)
            {
                Username = user;
                Name = name;
                Lastname = lastname;
                Phones = new Dictionary<string, string>();
                Phones.Add("House", housephone);
            }
    
            public void Add_Phone(string type,string num)
            {
                Phones.Add(type, num);
            }
        }
