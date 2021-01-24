    IEnumerable<Room> availableRooms = myDbContext.Rooms
        .Where(room => room.IsAvailable) 
        .Select(room => new ComboDisplay<Room>
        {
             Display = room.Name,
             Value = new Room
             {
                 Id = room.Id,
                 ...
             },
        })
        // add a dummy value if nothing is selected
        .Concat(new Room[]
        {
            Display = "Please select a room",
            Value = null, // meaning: nothing selected
        });
