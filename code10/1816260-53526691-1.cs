    string[] pushSections = cmd.Split(new[]{"-push"});
    foreach (string sect in pushSections )
    {
       string[] args = sect.Split('$', StringSplitOptions.RemoveEmptyEntries);
       foreach (string arg in args)
       {
           var poco = new ArgsPoco();
           SetProperty(arg, poco);
       }
       _somePocoList.Add(poco);
    }
    private void SetProperty(string arg, ArgsPoco poco)
    {
        string item = arg.Trim();
        int val = Convert.ToInt32(item.Substring(1).Trim());
        if (item.StartsWith("a"))
            poco.A = val;
        else if (item.StartsWith("b"))
            poco.B = val;
        else if (item.StartsWith("c"))
            poco.C = val;
    }
