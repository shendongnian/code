    private static void FillVariables(Pipeline pipeline, Hashtable scriptParameters)
    {
      // Add additional variables to PowerShell
      if (scriptParameters != null)
      {
        foreach (DictionaryEntry entry in scriptParameters)
        {
          CommandParameter Param = new CommandParameter(entry.Key as String, entry.Value);
          pipeline.Commands[0].Parameters.Add(Param);
        }
      }
    }
