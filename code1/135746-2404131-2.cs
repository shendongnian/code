	string[] inputs = { "456", "4445552222", "444555222288", "44455522226789" };
    string pattern = @"(\d{3})(\d{3})(\d{4})(\d*)";
	foreach (string input in inputs)
    {
        string result = Regex.Replace(input, pattern, m =>
        {
            if (m.Value.Length >= 10)
            {
                return String.Format("({0}) {1}-{2}",
                    m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value)
                        + (m.Value.Length > 10 ? " x" + m.Groups[4].Value : "");
            }
            return m.Value;
        });
        Console.WriteLine("Regex result: " + result);
    }
