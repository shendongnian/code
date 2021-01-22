    static void Main(string[] args)
    {
        Console.Clear();
        PrintLine();
        PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
        PrintLine();
        PrintRow("", "", "", "");
        PrintRow("", "", "", "");
        PrintLine();
        Console.ReadLine();
    }
    
    static void PrintLine()
    {
        Console.WriteLine(new string('-', 73));
    }
    
    static void PrintRow(string column1, string column2, string column3, string column4)
    {
        Console.WriteLine(
            string.Format("|{0}|{1}|{2}|{3}|", 
                AlignCentre(column1, 17), 
                AlignCentre(column2, 17), 
                AlignCentre(column3, 17), 
                AlignCentre(column4, 17)));
    }
    
    static string AlignCentre(string text, int width)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width-text.Length)/2).PadLeft(width);
        }
    }
