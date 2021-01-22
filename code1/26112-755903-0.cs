    class AnimalOwner<TAnimal>
    {
      virtual TAnimal OwnedAnimal {get;set;}
    }
    
    class CatOwner : AnimalOwner<Cat>
    {
    }
    
    class DogOwner : AnimalOwner<Dog>
    {
    }
