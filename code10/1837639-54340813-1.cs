                string pattern = @"(.*?_)?(\d{4}_\d{1}_\d{8}(_\d+))(?!.*\w)";
                Regex regex = new Regex(pattern, RegexOptions.Singleline);
                string Data1 = @"0aa_2019_1_20181234_111111111111";
                string Data2 = @"2019_8_8";
                // First Sample
                Match Re = regex.Match(Data1);
                if(Re.Groups.Count < 2)
                    Console.WriteLine("Invalid Input!");
                else
                    Console.WriteLine(Re.Groups[2]);
                // Second Sample
                Re = regex.Match(Data2);
                if (Re.Groups.Count < 2)
                    Console.WriteLine("Invalid Input!");
                else
                    Console.WriteLine(Re.Groups[2]);
