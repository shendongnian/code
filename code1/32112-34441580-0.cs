    IAnimal animal = ...;
    switch (animal.GetType().Name)
    {
      case "Peacock":
        var peacock = animal as Peacock;
        // Do something using the specific methods/properties of Peacock
        break;
      case "Lion":
        var peacock = animal as Lion;
        // Do something using the specific methods/properties of Lion
        break;
       etc...
    }
