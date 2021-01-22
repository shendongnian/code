    T Get<T>(T parameterOnlyToInferTheType)
    {
        IList<Animal> animals= zoo.GetAnimalsOfType<T>();  
        return animals[0];
    }
    
    animal = MockRepository.GenerateStub<Animal>();
    zoo.AddAnimal(animal);  
    Animal expected = Get(animal);
    Assert.That(expected, Is.EqualTo(animal)); 
