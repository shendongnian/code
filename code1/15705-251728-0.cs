    private List<int> modules;
    public string ModuleIds
    {
      set{
        if (!string.IsNullOrEmpty(value))
        {
        if (modules == null) modules = new List<int>();
        var ids = value.Split(new []{','});
        if (ids.Length>0)
          foreach (var id in ids)
            modules.Add((int.Parse(id)));
        }
    }
