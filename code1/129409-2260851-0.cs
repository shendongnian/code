         static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[L|M|D]$", RegexOptions.IgnoreCase);
            System.Console.WriteLine("Enter Text");
            String str = System.Console.ReadLine();
            Match match = regex.Match(str);
            if (match.Success == true)
            {
                System.Console.WriteLine("Success");
            }
            else
            {
                System.Console.WriteLine("Fail");
            }
            System.Console.ReadLine();
        }
