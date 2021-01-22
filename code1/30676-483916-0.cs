            string input1 = "smtp:jblack@test.com;SMTP:jb@test.com;X400:C=US;A= ;P=Test;O=Exchange;S=Jack;G=Black;";
            string input2 = "X400:C=US;A= ;P=Test;O=Exchange;S=Jack;G=Black;;smtp:jblack@test.com;SMTP:jb@test.com";
            Regex splitEmailRegex = new Regex(@"(?<key>\w+?):(?<value>.*?)(\w+:|$)");
            List<string> sets = new List<string>();
            while (input2.Length > 0)
            {
                Match m1 = splitEmailRegex.Matches(input2)[0];
                string s1 = m1.Groups["key"].Value + ":" + m1.Groups["value"].Value;
                sets.Add(s1);
                input2 = input2.Substring(s1.Length);
            }
            foreach (var set in sets)
            {
                Console.WriteLine(set);
            }
            
            Console.ReadLine();
