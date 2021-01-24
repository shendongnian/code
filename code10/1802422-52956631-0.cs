    public Boat GetByName(string name)
    {
       var boat = DbContext.Boat
                 .Include(boat => boat.ClassBoat)
                 .Include(boat => boat.TypeOfBoat)
                 .FirstOrDefault(boat => boat.Name == name);
       return boat;
    }
