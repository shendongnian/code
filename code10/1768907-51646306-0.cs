    public static void Update(Client c, string s)
    {
        var json = File.ReadAllText(fileName);
        List<Client> list = JsonConvert.DeserializeObject<List<Client>>(json);
        Client found = list.Where(x => x.Name == s).Single();
        found.Name = c.Name;
        found.Path = c.Path;
        var updatedJson = JsonConvert.SerializeObject(list);
        File.WriteAllBytes(fileName, Encoding.ASCII.GetBytes(updatedJson));
    }
