            string fneh = "smtp:jblack@test.com;SMTP:jb@test.com;X400:C=US;A= ;P=Test;O=Exchange;S=Jack;G=Black;";
            string[] parts = fneh.Split(new char[] { ';' });
            List<string> addresses = new List<string>();
            StringBuilder x400 = new StringBuilder();
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("smtp", StringComparison.InvariantCultureIgnoreCase))
                {
                    addresses.Add(parts[i]);
                }
                else
                {
                    x400.Append(parts[i]);
                }
            }
            foreach (string emailAddress in addresses)
            {
                Console.WriteLine(emailAddress);
            }
            Console.WriteLine(x400);
            Console.ReadKey();
