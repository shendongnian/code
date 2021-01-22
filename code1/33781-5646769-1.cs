    public partial class Dog {
        public string BreedName  { get; set; }}
    List<Dog> GetDogsWithBreedNames(){
        var db = new DogDataContext(ConnectString);
        var result = (from d in db.Dogs
                      join b in db.Breeds on d.BreedId equals b.BreedId
                      select new
                      {
                          Name = d.Name,
                          BreedName = b.BreedName
                      }).ToList()
                        .Select(x=> 
                              new Dog{
                                  Name = x.Name,
                                  BreedName = x.BreedName,
                              }).ToList();
    return result;}
