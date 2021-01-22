    public class Cat:Animal
    {
      Poo Animal.Excrement { get { return Excrement; } }
      public RadioactivePoo Excrement { get { return new RadioactivePoo(); } }
    }
