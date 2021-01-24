    public static void GetPizza()
    {
        var pizzaSizesString = string.Join(", ", Enum.GetNames(typeof(PizzaSize)));
        Console.WriteLine($"Pizza sizes: {pizzaSizesString}");
        Console.Write("Enter the size of the pizza you want: ");
        PizzaSize pizzaSize = PizzaSize.Small;
        bool answerOk = false;
        while (!answerOk)
        {
            var size = Console.ReadLine();
            answerOk = Enum.TryParse(size, out pizzaSize);
            if (!answerOk)
            {
                Console.Write(@"Please enter one of: {pizzaSizesString}");
            }
        }
        Console.Write("Would you like extra toppings on that (true/false): ");
        bool toppings = false;
        answerOk = false;
        while (!answerOk)
        {
            var toppingsString= Console.ReadLine();
            answerOk = TryParseTrueFalse(toppingsString, out toppings);
            if (!answerOk)
            {
                Console.Write(@"Please enter true or false: ");
            }
        }
        var toppingNote = toppings ? " with extra toppings" : string.Empty;
        var price = PizzaPrices[pizzaSize];
        if (toppings)
        {
            price += ToppingsPrices[pizzaSize];
        }
        Console.WriteLine($"You ordered a {pizzaSize} pizza{toppingNote} for a total of {price}");
        Console.ReadLine();
    }
