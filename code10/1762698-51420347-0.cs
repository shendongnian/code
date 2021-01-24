            var stations = new Dictionary<string, string>();
            var lines = File.ReadAllLines(@"C:\temp\22.txt");
            foreach (var l in lines)
            {
                var lsplit = l.Split(',');
                if (lsplit.Length > 1)
                {
                    var newkey = lsplit[0];
                    var newval = lsplit[1] + lsplit[2];
                    stations[newkey] = newval;
                }
            }
            //read all key and value in file
            foreach (KeyValuePair<string, string> item in stations)
            {
                Console.WriteLine(item.Key + " = " + item.Value);
            }
            Console.ReadLine();
