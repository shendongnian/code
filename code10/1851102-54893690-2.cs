    Type typeWeWant = sampleAnimal.GetType();
    foreach (var x in listOfAnimals) {
      // with check only by type of typeWeWant
      if (x.GetType() == typeWeWant) {
         return true;
      }
      // depends on your needs you can use one of following
      // will check if typeWeWant is subclass of x
      if (typeWeWant.IsSubclassOf(x.GetType()) {
         return true;
      }
      // will check if x is subclass of typeWeWant
      if (x.GetType().IsSubclassOf(typeWeWant)) {
         return true;
      }
    }
