    // The user is entering the numbers (code copied from your question).
    for (int i = 0; i < index.Length; i++)
    {
        Console.WriteLine("Enter number: ");
        index[i] = int.Parse(Console.ReadLine());
    }
    // Now display the numbers entered.
    for (int i = 0; i < index.length; i++)
    {
        Console.WriteLine(index[i]);
    }
    // Finally, search for the element and display where it is.
    int elementToSearchFor;
    if (int.TryParse(Console.ReadLine(), out elementToSearchFor))
    {
        // TODO: homework to do.
    }
