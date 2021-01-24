    var list = DataObjectManager.GetInvalidFields();
    for(int i = list.Count - 1; i >= 0; i--)
    {
        if(list[i].ControlName == "tbMCBNumber").Remove(list[i]);
    }
