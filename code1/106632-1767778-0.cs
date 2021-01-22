    List<Button> buttonList = new List<Button>();
    buttonList.Add(Monday0700Button);
    buttonList.Add(Monday0730Button);
    buttonList.Add(Monday0800Button);
    buttonList.Add(Monday0830Button);
    buttonList.Sort((l,r) => l.ID.CompareTo(r.ID));
