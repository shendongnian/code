    Console.WriteLine("First Delimiter : ");
            int Position = 22;
            char delimiter = ',';
            string pattern = @"^([^" + delimiter + "]*" + delimiter + "){" + (Position - 1) + @"}(.*?)" + delimiter;
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            // First Example
            string Data = @"AAV,zzz,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22ABC,23,24,24";
            Match Re = regex.Match(Data);
            if (Re.Groups.Count > 0)
                Console.WriteLine("\tMatch found : " + Re.Groups[2]);
            // Second Example
            Console.WriteLine("Second Delimiter : ");
            Position = 8;
            delimiter = ';';
            pattern = @"^([^" + delimiter + "]*" + delimiter + "){" + (Position - 1) + @"}(.*?)" + delimiter;
            Data = @"61d2e3f6-bcb7-4cd1-a81e-4f8f497f0da2;0;192.100.0.102:4362;2014-02-14;283;0;354;23;0;;;""0x8D15A2913C934DE"";Thursday, 19-Jun-14 22:58:10 GMT;";
            regex = new Regex(pattern, RegexOptions.Singleline);
            Re = regex.Match(Data);
            if (Re.Groups.Count > 0)
                Console.WriteLine("\tMatch found : " + Re.Groups[2]);
