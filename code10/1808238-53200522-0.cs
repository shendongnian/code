    List<string> lmlcCodes = new List<string>();
    foreach (var item in model.CheckListItems)
    {
        var code = item.LMCLCode;
        lmlcCodes.Add(code);
    }
    
    var checkListItems = this.appData.LMLoanChecklist.Find(x => x.LMAutoID == model.LMAutoID)
                        .Where(x => lmlcCodes.Contains(x.LMCLCode));
