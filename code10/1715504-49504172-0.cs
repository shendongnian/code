    void Update(string name, string newName)
    {
        var user = userData.Single(u => u.Name == name);
        user.Name = newName;
    }
