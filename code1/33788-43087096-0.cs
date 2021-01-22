    public List<(string Name, string BreedName)> GetDogsWithBreedNames()
    {
        var db = new DogDataContext(ConnectString);
        var result = from d in db.Dogs
                 join b in db.Breeds on d.BreedId equals b.BreedId
                 select new
                 {
                    Name = d.Name,
                    BreedName = b.BreedName
                 }.ToList();
        return result.Select(r => (r.Name, r.BreedName)).ToList();
    }
