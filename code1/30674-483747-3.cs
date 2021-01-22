    string fneh = "X400:C=US400;A= ;P=Test;O=Exchange;S=Jack;G=Black;smtp:jblack@test.com;X500:C=US500;A= ;P=Test;O=Exchange;S=Jack;G=Black;SMTP:jb@test.com;";
    string[] parts = fneh.Split(new char[] { ';' });
    List<string> addresses = new List<string>();
    StringBuilder x400 = new StringBuilder();
    StringBuilder x500 = new StringBuilder();
    string currentlyProcessing = string.Empty;
    for (int i = 0; i < parts.Length; i++)
    {
        if (parts[i].StartsWith("smtp", StringComparison.InvariantCultureIgnoreCase))
        {
            addresses.Add(parts[i]);
        }
        else
        {
            if (parts[i].StartsWith("x400", StringComparison.InvariantCultureIgnoreCase))
            {
                currentlyProcessing = "x400";
            }
            if (parts[i].StartsWith("x500", StringComparison.InvariantCultureIgnoreCase))
            {
                currentlyProcessing = "x500";
            }
            switch (currentlyProcessing)
            {
                case "x400":
                    x400.Append(parts[i]);
                    break;
                case "x500":
                    x500.Append(parts[i]);
                    break;
                default:
                    break;
            }
        }
    }
    foreach (string emailAddress in addresses)
    {
        Console.WriteLine(emailAddress);
    }
    Console.WriteLine(x400);
    Console.WriteLine(x500);
    Console.ReadKey();
