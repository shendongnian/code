    interface IPizza
    {
    }
    class Pizza1 : IPizza
    {
      public Pizza1(Pizza1Parameter p)
      {
      }
    }
    class Pizza2 : IPizza
    {
      public Pizza2(Pizza2Parameter p)
      {
      }
    }
    interface IPizzaParameter
    {
      object Type { get; set; }
    }
    class Pizza1Parameter : IPizzaParameter
    {
      public object Type { get; set; }
    }
    class Pizza2Parameter : IPizzaParameter
    {
      public object Type { get; set; }
    }
    static class PizzaFactory
    {
      public enum PizzaType
      {
        Pizza1,
        Pizza2,
      }
      public static IPizza CreatePizza(PizzaType type, IPizzaParameter param)
      {
        switch (type)
        {
          case PizzaType.Pizza1:
            return new Pizza1(param as Pizza1Parameter);
          case PizzaType.Pizza2:
            return new Pizza2(param as Pizza2Parameter);
        }
        throw new ArgumentException();
      }
    }
    class Program
    {
      static void Main()
      {
        var param1 = new Pizza1Parameter();
        var p1 = PizzaFactory.CreatePizza(PizzaFactory.PizzaType.Pizza1, param1);
      }
    }
