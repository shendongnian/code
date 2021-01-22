            string csv = @"
    Name  AA BB CC AA BB CC
    XX5            2  7  8b
    YY4            2  6  2
    ZZ3            8  21 9
    RR2   1  2  6
    SS1            6  7  23";
            string[] lines = csv.Split(new string[]{Environment.NewLine}, 
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] fields = Regex.Split(line, @"\s+");
                foreach (string field in fields)
                {
                    Console.Write(field);
                    Console.Write('\t');
                }
                Console.Write(Environment.NewLine);
            }
