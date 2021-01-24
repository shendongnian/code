    foreach (var question in File.ReadLines(text, Encoding.Unicode))
    {
        Console.WriteLine(question);
        string response = Console.ReadLine();
        potentialEmployee.Responses.Add(question, response);
    }
