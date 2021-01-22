    string lineGrab = error.StackTrace.Substring(error.StackTrace.Length - 5);
    int i = 0;
    int value;
    while (i < lineGrab.Length)
    {
        if (int.TryParse(lineGrab[i].ToString(), out value))
        {
            strLineNo.Append(lineGrab[i]);
        }
        i++;
    }
