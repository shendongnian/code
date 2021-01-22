    public class Dog { public string Name { get; set; } }
    public class Poodle : Dog { public void DoBackflip(){ System.Console.WriteLine("2nd smartest breed - woof!"); } }
    public static Poodle ConvertDogToPoodle(Dog dog)
    {
        return new Poodle() { Name = dog.Name };
    }
    List<Dog> dogs = new List<Dog>() { new Dog { Name = "Truffles" }, new Dog { Name = "Fuzzball" } };
    List<Poodle> poodles = dogs.ConvertAll(new Converter<Dog, Poodle>(ConvertDogToPoodle));
    poodles[0].DoBackflip();
