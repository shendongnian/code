    public IActionResult register([FromBody]Register command)
    {
        var newUser = new User(command.login, password);
        var newItem = new Item("TEST", newUser);
        newUser.Items.Add(newItem);
        _context.UsersTable.Add(newUser);
        _context.ItemsTable.Add(newItem); // Edit : I'm not sure, but try it without this line, it should work
        _context.SaveChanges();
    }
