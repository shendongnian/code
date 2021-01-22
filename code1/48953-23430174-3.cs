    public void SomeMethod()
    {
        var a = AnimalType.Amphibians;
        var b = AnimalType.Amphibians;
        if (a == b)
        {
            // should be equal
        }
        // call method as
        Foo(a);
        // using ifs
        if (a == AnimalType.Amphibians)
        {
        }
        else if (a == AnimalType.Invertebrate)
        {
        }
        else if (a == DogType.Golden_Retriever)
        {
        }
        // etc          
    }
    public void Foo(BaseAnimal typeOfAnimal)
    {
    }
