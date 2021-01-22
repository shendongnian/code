    string astring = ...;
    string[] values = astring.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    int a = Int32.Parse(values[0]);
    int b = Int32.Parse(values[1]);
    int c = Int32.Parse(values[2]);
