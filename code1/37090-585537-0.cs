    col = (col ?? "").Split(new char[] { ' ' }, 
        int.MaxValue, StringSplitOptions.RemoveEmptyEntries)
            .LastOrDefault();
    if (col != null)
    { 
        emptyRow.Append(String.Format(" '' AS {0},", col);
    }
