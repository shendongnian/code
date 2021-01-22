    // we search an array of strings for a name containing the letter “a”:
    static void Main()
    {
      string[] names = { "Rodney", "Jack", "Jill" };
      string match = Array.Find (names, ContainsA);
      Console.WriteLine (match);     // Jack
    }
    static bool ContainsA (string name) { return name.Contains ("a"); }
