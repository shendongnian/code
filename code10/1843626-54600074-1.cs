    const int arraySize = 4;
    string[] pizzaSizes = { "Small", "Medium", "Large", "X-Large" };
    decimal[] prices = { 6.99M, 8.99M, 12.50M, 15.00M };
    decimal[] extras = { 1.00M, 2.00M, 3.25M, 4.50M }; //extra toppings
    
    Console.WriteLine("Pizza Sizes: Small, Medium, Large, X-Large ");
    Console.Write("Enter a the pizza size you would like to order:");
    
    string pizzaSize = Console.ReadLine();
    int i = 0;
    // Important to have condition (i < arraySize) the first in evalution 
    while ((i < arraySize) && (pizzaSizes[i] != pizzaSize))
    {
        ++i;
    }
    
    if (i >= arraySize)
    {
        // Invalid input
        Console.WriteLine($"Invalid pizza size input: {pizzaSize}. Exiting");
        return;
    }
    
    Console.WriteLine("You selected a {0} pizza for ${1}", pizzaSizes[i], prices[i]);
    
    Console.WriteLine("Would you like extra toppings? true or false?");
    bool addons = Convert.ToBoolean(Console.ReadLine());
    Console.WriteLine("You selected {0}", addons);
    
    if (addons)
    {
        Console.WriteLine($"You ordered a {pizzaSizes[i]} pizza with extra toppings. The total price is {prices[i] + extras[i]}");
    }
    else
    {
        Console.WriteLine($"You ordered a {pizzaSizes[i]} pizza without extra toppings. The total price is {prices[i]}");
    }
    Console.ReadLine();
