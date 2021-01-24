    DateTime date = DateTime.MinValue;
    string[] dateFormats = { "dd.MM.yyyy", "ddMMyyyy" };
    string userInput = "30.10.2000"; // or "30102000"
    bool isValid = DateTime.TryParseExact(userInput, dateFormats, null, DateTimeStyles.None, out date);
    Console.WriteLine($"{date:O}"); // prints date in ISO format
