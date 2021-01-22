    static void Main(string[] args)
    {
        string inputFile = @"c:\temp\input.txt";
        string outputFile = @"c:\temp\output.txt";
        using (StreamReader reader = File.OpenText(inputFile))
        using(Stream outputStream = File.OpenWrite(outputFile))
        using (StreamWriter writer = new StreamWriter(outputStream))
        {
            do
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                writer.WriteLine(TransformLine(line));
            } while (true);
        }
    
        File.Delete(inputFile);
        File.Move(outputFile, inputFile);
    }
    private static char[] separator = "|".ToCharArray();
    private static string TransformLine(string line)
    {
        string[] columns = line.Split(separator);
        columns[DATE_COLUMN] = ReformatDate(columns[4]);
        return string.Join("|", columns);
    }
    
    private static string ReformatDate(string input)
    {
        return DateTime.ParseExact(input, "yyyyMMdd", CultureInfo.InvariantCulture)
            .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
    }
