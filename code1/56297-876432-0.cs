    using (DatabaseEntities e = new DatabaseEntities()) {
        for (int i = 0; i < 50; i++) {
            User u = new User();
            u.Nome = "User" + i.ToString();
            e.AddToUser(u);
        }
        int c = e.SaveChanges(true);
    }
    using (DatabaseEntities e = new DatabaseEntities()) {
        List<User> us = e.User.Where<User>(x => x.ID < 50).ToList<User>();
        foreach (User u in us)
            Console.WriteLine("ID: " + u.ID + " Hello from " + u.Nome);
    }
    Console.ReadKey();
