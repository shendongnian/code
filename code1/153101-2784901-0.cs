    public Animal CreateAnimal(string parameter)
    {
        if(parameter == "cat")
            return new Cat();
        else
            return new Dog();
    }
    var strings = new[]{ "cat", "cat", "dog" };
    var animals = strings.Select(s => CreateAnimal(s)).ToList();
