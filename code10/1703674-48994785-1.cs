    try
    {
        var user = new MyUser() { UserName = Context.User.Identity.Name };
        //here I was doing user.Rooms.Add(roma); where Romms is null
        roma.Rooms = new ICollection<PrivateUser>();
        //now we can add the room to Rooms
        user.Rooms.Add(roma);
        //and here was the below commented code from a Stackoverflow Answer
        //_context.MyUsers.Attach(user).Property(u => u.Rooms).IsModified = true;
        //we just have to use Update here;
        _context.MyUsers.Attach(user);
        _context.MyUsers.Update(user);
        roma.Users.Add(user);
        await _context.Rooms.AddAsync(roma);
        await _context.SaveChangesAsync();
    }
