    for(int i = 0; i < table.Columns.Count; i++)
    {
        Write(string.Format("(ordinal_{0}_{1}.HasValue)", table.Name, table.Columns[i].Name));
        if(i < (table.Columns.Count - 1))
        {
            WriteLine(" ||");
        }
    }
