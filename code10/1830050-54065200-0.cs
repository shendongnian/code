Toppings.AddRange();
    public Pizza(ECrust crust, EPizzaSize size, List<EToppings> lsToppings) : this()
    {
      Crust = crust;
      Price = Cost[size];
      Size = size;
      Toppings.AddRange(lsToppings);
    }
