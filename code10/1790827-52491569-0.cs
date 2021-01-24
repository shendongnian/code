        public static void Validate(string input, int number, string prompt1, string prompt2, string prompt3)
        {
            while (string.IsNullOrEmpty(input) || (!(int.TryParse(input, out number))) || number <= 0 || number > 16)
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(prompt1);
                    input = Console.ReadLine();
                }
                else 
                {
                    var accountNumberInArray = input.Split(' ');
                    string accountNumber = string.Empty;
                    foreach (var item in accountNumberInArray)
                    {
                        accountNumber += item;
                    }
                    if (accountNumber.Length < 16)
                    {
                        //Do something 
                    }
                    else if (accountNumber.Length > 16)
                    {
                        //Do something 
                    }
                    else if(accountNumber.Length == 16)
                    {
                        //Do Something 
                    }
                }                
            }
        }
