            Regex regex = new Regex(@"ERISRequest_(?<val>[a-zA-Z0-9]{1,}.csv)");
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            foreach (FileInfo fi in di.GetFiles())
            {
                var match = regex.Match(fi.Name);
                if (match.Success)
                {
                    Console.WriteLine(match.Groups["val"].Value);
                }
            }
            Console.ReadLine();
