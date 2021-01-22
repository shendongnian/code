    private const int DATE_COLUMN = 4;
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(@"c:\temp\input.txt"))
        {
            do
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                line = TransformLine(line);
            } while (true);
        }
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
