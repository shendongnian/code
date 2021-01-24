    int selSize = -1;
    for (int i = 0; i < size.Length; i++)
    {
        if (size[i] == pizzaSize)
        {
            selSize = i;
            break;
        }
    }
    
    if (addons == true)
    {
        Console.WriteLine("You ordered a {0} pizza with extra toppings. The total price is {1}", pizzaSize, price[selSize] + extra[selSize]);
    }
    else
    {
        Console.WriteLine("You ordered a {0} pizza for ${1}", pizzaSize, price[selSize]);
    }
    Console.ReadLine();
