    public IEnumerable<Dog> GetDogs()
    {
        using (var db = new DogDataContext(ConnectString))
        {
            db.LoadOptions.LoadWith<Dog>(i => i.Breed);
            return db.Dogs.ToArray();
        }
        
    }
