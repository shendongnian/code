    var input = new HashSet<int>(); // accepts only unique values
    while (input.Count() < 5)
    {
        Console.WriteLine("enter value");
        int temp; // In newer C# it can be moved to TryParse e.g "out int temp"
        if (Int32.TryParse(Console.ReadLine(), out temp))
        {
            if (input.Contains(temp))
            {
                Console.WriteLine("this number is already in collection");
            }
            else
            {
                input.Add(temp);
            }
        }
        else
        {
            Console.WriteLine("incorrect value");
        }
    }
    // order by(lambda_expression) allows you to specify by "what things" 
    // you'd want to order that collection. In this case you're just sorting 
    // by numbers, but if it was complex objects collection then you'd be
    // able to sort by e.g student => student.Money; which would mean that 
    // you're sorting students by their Money count.
    foreach (var number in input.OrderBy(x => x))
    {
        Console.WriteLine(number);
    }
