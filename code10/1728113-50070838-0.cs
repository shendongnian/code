            string delimiter = ",;";
            string sTimeUpper = "2017-04-25 14:16:30.000";
            string sTimeLower = "2017-04-25 14:15:30.000";
            DateTime TimeUpper = DateTime.Parse(sTimeUpper);
            DateTime TimeLower = DateTime.Parse(sTimeLower);
            Console.WriteLine($"TimeLower = {TimeLower}");
            Console.WriteLine($"TimeUpper = {TimeUpper}");
            
            List<string> res = (File.ReadAllLines(@"TimeStamp.txt")
                .Skip(1)
                .Select(line => line.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                .Where(fields => DateTime.Parse(fields[3]) > TimeLower && DateTime.Parse(fields[3]) < TimeUpper)
                .Select(fields => string.Join(",", fields))
                .ToList<string>());
            
            Console.WriteLine("Requested readings:");
            foreach (string item in res)
            {
                Console.WriteLine(item);
            }
