    string x = "text or int";
    if (int.TryParse(x, out int output))
    {
      // Console.WriteLine(x);
      // x is an int
      // Do something
    }
    else
    {
      // x is not an int
    }
