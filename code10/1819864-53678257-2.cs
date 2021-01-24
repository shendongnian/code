    var listOfPrograms = new[] { "Google Chrome", "Notepad" };
    var processDictionary = BuildProcessDictionary();
    foreach (var item in listOfPrograms)
    {
      try
      {
        var programInstances = processDictionary.Where(x => x.DisplayName != null && x.DisplayName.Equals(item));
        foreach (var programInstance in programInstances)
        {
          programInstance.Process.Kill();
        }
      }
      catch (Exception )
      {
         // Log items that wasn't found or coudn't be killed.
        Console.WriteLine($"Could not find or kill process {item}");
      }
    }
