    public delegate Duck GetDuckDelegate();
    
    public GetDuckDelegate GiveMeTheDuckFactoryMethod(string type)
    {
      switch(type)
      {
        case "Rubber":
          return new GetDuckDelegate(CreateRubberDuck);
        case "Mallard":
          return new GetDuckDelegate(CreateMallardDuck);
        default:
          return new GetDuckDelegate(CreateDefaultDuck);
      }
    }
    
    public Duck CreateRubberDuck()
    {
      return new RubberDuck();
    }
    
    public Duck CreateMallardDuck()
    {
      return new MallardDuck();
    }
    
    public Duck CreateDefaultDuck()
    {
      return new Duck();
    }
