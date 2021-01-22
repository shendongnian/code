    for (int i = 0; i < Collection.Count; i++)
    {
        if (Collection[i].Name == "Alan")
        {
            break;  // We found the name we wanted!
        }
        // Otherwise: Keep going to look for the name further on.
    }
    if (i == Collection.Count)
    {
        Console.WriteLine("Alan is not found");
    }
    else
    {
        Console.WriteLine("Alan found at position {0}", i);
    }
