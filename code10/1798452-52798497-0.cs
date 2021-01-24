    // Array of data
    string[] values = 
        {
        "order customer joe intel 300",
        "order customer john amd 200",
        "order customer bob Qualcomm 300"
    };
    // Loop the array of data
    foreach (string value in values)
    {
        // split up the data in to the words
        string[] split = value.Split(' ');
        // Get the values (assuming they are always in the same place)
        string name = split[2];
        string company = split[3];
        string quantity = split[4];
        // Create the formatted string
        string formattedString = $"Order placed for {name} - {quantity} units of {company}";
        // Do something with the string ..
        Console.WriteLine(formattedString);
    }
