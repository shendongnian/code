    public Pizza(ECrust crust, EPizzaSize size, params EToppings[] toppings) : this()
    {
      Crust = crust;
      Price = Cost[size];
      Size = size;
      Toppings.AddRange(toppings);
    }
