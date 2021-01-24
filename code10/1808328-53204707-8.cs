    var shelter = Shelter.Create();
    shelter.Animal = new Lion();
    // OR:
    // var shelter = Shelter.Create(new Lion());
    var animal = shelter.Animal;
    var catShelter = Shelter.Create<Cat>();
    catShelter.Animal = new Cat();
    // OR:
    // var catShelter = Shelter.Create(new Cat());
    var cat = catShelter.Animal;
