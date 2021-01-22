            Regex regex = new Regex(@"^[a-z | 0-9 | /,]*$", RegexOptions.IgnoreCase);
            System.Console.Write("Enter Text");
            String s = System.Console.ReadLine();
            Match match = regex.Match(s);
            if (match.Success == true)
            {
                System.Console.WriteLine("True");
            }
            else
            {
                System.Console.WriteLine("False");
            }
            System.Console.ReadLine();
