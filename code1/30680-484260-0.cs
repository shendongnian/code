        string input =
            "smtp:jblack@test.com;SMTP:jb@test.com;X400:C=US;A= ;P=Test;O=Exchange;S=Jack;G=Black;";
        string[] parts = input.Split(';');
        List<string> output = new List<string>();
        foreach(string part in parts)
        {
            if (part.Contains(":"))
            {
                output.Add(part + ";");
            }
            else if (part.Length > 0)
            {
                output[output.Count - 1] += part + ";";
            }
        }
        foreach(string s in output)
        {
            Console.WriteLine(s);
        }
