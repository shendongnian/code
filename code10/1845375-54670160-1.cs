    string[] questions = File.ReadAllLines(text, Encoding.Unicode);
    foreach (var question in questions)
    {
        Console.WriteLine(question);
        string response = Console.ReadLine();
        potentialEmployee.Responses.Add(question, response);
    }
