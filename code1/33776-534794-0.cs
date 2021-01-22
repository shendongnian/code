    public class DogWithBreed
    {
        public Dog Dog { get; set; }
        public string BreedName  { get; set; }
    }
    public IQueryable<DogWithBreed> GetDogsWithBreedNames()
    {
        var db = new DogDataContext(ConnectString);
        var result = from d in db.Dogs
                     join b in db.Breeds on d.BreedId equals b.BreedId
                     select new DogWithBreed()
                            {
                                Dog = d,
                                BreedName = b.BreedName
                            };
        return result;
    }
