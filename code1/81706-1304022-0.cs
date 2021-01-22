    string line = "23"; // or whatever.
    string str = line.Substring(0,1);
    int i = 0;
    if (Int32.TryParse(str, out i)) {
       Console.WriteLine(i);
    } else {
        Console.WriteLine ("Error converting '" + line + "', '" + str + "'.");
    }
