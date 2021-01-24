               static void Main(string[] args)
                {
                    RootAnimal list = new RootAnimal();
                    list.allAnimal = new AllAnimal();
                    Animal myAnimal = new Animal();
                    list.allAnimal.Animal = new List<Animal>();
        
                    myAnimal = new Animal();
                    myAnimal.AnimalType = "dog";
                    myAnimal.AnimalCount = 3;
                    list.allAnimal.Animal.Add(myAnimal);
                    var json = JsonConvert.SerializeObject(list);
                }
    
       public class Animal
        {
            public string AnimalType { get; set; }
            public int AnimalCount { get; set; }
        }
    
        public class AllAnimal
        {
            public List<Animal> Animal { get; set; }
        }
    
        public class RootAnimal
        {
            public AllAnimal allAnimal { get; set; }
        }
