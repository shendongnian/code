    public Counter InputMove(Board b)
    {
       string s;
       Console.Write("Row: ");
       s = Console.ReadLine();
       int row = Convert.ToInt32(s);
       if (s == "") return null;
       Console.Write("Column: ");
       s = Console.ReadLine();
       if (s == "") return null;
       int column = Convert.ToInt32(s);
       return b.GetCounter(row, column);
    }
