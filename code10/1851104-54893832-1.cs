    Type typeWeWant = sampleAnimal.GetType();
    foreach (var x in listOfAnimals)
    {
        if (typeWeWant.IsSubclassOf(x.GetType()))
        {
            return true;
        }
    }
