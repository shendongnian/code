    public void AddGlobalVariable(string name, dynamic content)
    {
      if (GlobalMergeVars == null)
      {
        GlobalMergeVars = new List<MergeVar>();
      }
      var mv = new MergeVar {Name = name, Content = content};
      GlobalMergeVars.Add(mv);
    }
