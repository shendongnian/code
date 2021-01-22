    string[] mathlines = File.ReadAllLines(@"C:\math.txt");
    string[] addlines = File.ReadAllLines(@"K:\addlines.txt");
    string[] finallines = new string[mathlines.Length];
    var addlinesLookup = new Dictionary<string, string>();
    for (int i = 0; i < addlines.Length; i++)
    {
      string[] parts = addlines[i].Split('|');
      if (parts.Length == 2) // Will there ever be more than 2 parts?
      {
        addlinesLookup.Add(parts[0], parts[1]);
      }
    }
    for (int i = 0; i < mathlines.Length; i++)
    {
      string[] parts = mathlines[i].Split('|');
      if (parts.Length >= 1)
      {
        if (addlinesLookup.ContainsKey(parts[0]))
        {
          finallines[i] = mathlines[i] + "|" + addlinesLookup[parts[0]] + "\n";
        }
        {
          finallines[i] = mathlines[i] + "\n";
        }
      }
    }
    File.AppendAllLines(@"C:\final.txt", finallines, Encoding.ASCII);
