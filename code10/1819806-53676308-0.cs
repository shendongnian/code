    public void AddToList(List<string> listToAdd, List<CheckBox> listToIterate)
    {
      foreach (var i in listToIterate)
      {
        listToAdd.Add(i.Text);
      }
    }
