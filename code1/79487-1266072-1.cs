    public void ProcessReturn(string[] selectedNames)
    {
      foreach (string nameID in selectedNames)
      {
        ProcessNameByID(nameID);
      }
    }
