    public class Animal
    {
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
    	
    	public static double AverageAttributeDelegates(List<Animal> animals, Func<Animal, int> getter)
    	{
    	    double average = 0;
    	
    	    foreach(Animal animal in animals)
    		{
    	        average += getter(animal);
    		}
    	
    	    return average/animals.Count;
    	}
    }
    List<Animal> animals = new List<Animal> { new Animal { Age = 1, Height = 2, Weight = 2.5, Name = "a" }, new Animal { Age = 3, Height = 1, Weight = 3.5, Name = "b" } };
    Animal.AverageAttributeDelegates(animals, x => x.Age); //2
    Animal.AverageAttributeDelegates(animals, x => x.Height); //1.5
