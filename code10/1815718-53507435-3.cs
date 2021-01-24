    string json = File.ReadAllText("a.json");
    PersonA personA = JsonConvert.DeserializeObject<PersonA>(json);
    PersonB personB = new PersonB() { Email = personA.Email, CreatedDate = personA.CreatedDate };
    foreach(var role in personA.Roles)
    {
        var roleB = role as RoleB;
        if (roleB.town != null)
        {
            personB.RolesB.Add(roleB);
        }
        else
        {
            personB.RolesA.Add(new RoleA() { name = roleB.name, type = roleB.type });
        }
    }
