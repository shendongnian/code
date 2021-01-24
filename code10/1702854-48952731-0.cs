    static void Main(string[] args)
        {
            var Example1CsvPath = @"C:\Inetpub\Poligon\Poligon\Resources\Example1.csv";
            var Example2CsvPath = @"C:\Inetpub\Poligon\Poligon\Resources\Example2.csv";
            var Example3CsvPath = @"C:\Inetpub\Poligon\Poligon\Resources\Example3.csv";
            var EmailsToDelete = new List<string>();
            var Result = new List<string>();
            foreach(var Line in System.IO.File.ReadAllLines(Example1CsvPath))
            {
                if (!string.IsNullOrWhiteSpace(Line) && Line.IndexOf('@') > -1)
                {
                    EmailsToDelete.Add(Line.Trim());
                }
            }
            foreach (var Line in System.IO.File.ReadAllLines(Example2CsvPath))
            {
                if (!string.IsNullOrWhiteSpace(Line))
                {
                    var Values = Line.Split(' ');
                    if (!EmailsToDelete.Contains(Values[4]))
                    {
                        Result.Add(Line);                        
                    }
                }
            }
            System.IO.File.WriteAllLines(Example3CsvPath, Result);
        }
