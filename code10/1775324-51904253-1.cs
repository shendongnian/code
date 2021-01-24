    private static void InsertData<T>(string[,] matrix)
    {
        // Just add dummy data while testing
        matrix[0, 0] = "1";
        matrix[0, 1] = "FirstName";
        matrix[0, 2] = "LastName";
        matrix[0, 3] = "123 Main St";
        matrix[0, 4] = "98765";
        matrix[0, 5] = "(123) 456-7890";
        matrix[0, 6] = "user@provider.com";
        return;
        matrix[0, matrix.GetLowerBound(1)] = "1";
        for (var j = 1; j < matrix.GetLength(1); j++)
        {
            do
            {
                Console.Write($"\nInsert {GetHeader<T>(j)}: ");
                matrix[0, j] = Console.ReadLine();
            } while (string.IsNullOrEmpty(matrix[0, j]));
        }
    }
    private static void ListData<T>(string[,] matrix)
    {
        var array = new string[matrix.GetUpperBound(1)];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = matrix[0, i];
        }
        PrintRow(array);
        PrintLine();
    }
    private static string GetHeader<T>(int i) => Enum.GetName(typeof(T), i);
    private static void ShowHeader<T>(string[,] matrix)
    {
        var array = new string[matrix.GetUpperBound(1)];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = GetHeader<T>(i);
        }
        PrintLine();
        PrintRow(array);
        PrintLine();
    }
    private static void PrintLine()
    {
        Console.WriteLine(new string('-', Console.WindowWidth - 1));
    }
    private static void PrintRow(IReadOnlyCollection<string> columns)
    {
        var width = (Console.WindowWidth - 1 - columns.Count) / columns.Count;
        var row = columns.Aggregate("|", (current, column) => current + AlignCentre(column, width) + "|");
        Console.WriteLine(row);
    }
    static string AlignCentre(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
        return string.IsNullOrEmpty(text)
            ? new string(' ', width)
            : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
    enum ClientHeader { Id, Name, Surname, Addres, CodPostal, Telephone, Email, State };
    private static void Main()
    {
        var client = new string[3, 7];
        InsertData<ClientHeader>(client);
        Console.Clear();
        ShowHeader<ClientHeader>(client);
        ListData<ClientHeader>(client);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
    private static ConsoleKeyInfo GetKeyFromUser(string prompt)
    {
        Console.Write(prompt);
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }
