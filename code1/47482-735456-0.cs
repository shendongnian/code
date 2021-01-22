    List<Guest> guests = new List<Guest>();
    for(int i=0; i<numberOfGuests; i++)
    {
      guests.Add(new Guest()
      {
        Title = "Mr",
        Firstname = "Test",
      });
    }
    return guests.ToArray();
