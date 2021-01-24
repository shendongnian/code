     Type typeWeWant = sampleAnimal.GetType();
     foreach (var x in listOfAnimals)
     {
         if (typeWeWant.IsInstanceOfType(x))
         {
             return true;
         }
     }
