    var languageControls = new List<RadioButtonList> { rblCSharp, rblVbNet, rblVbClassic, rblCrystal, rblSsrs, rblSql2005, rblUiWeb };
    
    foreach(var rbl in languageControls)
    {
        rbl.Items.Clear();
        // this could be a foreach instead, but I kept your original code
        for (int i = 0; i < level.GetLength(0); i++)
        {
            rbl.Items.Add(level[i]);
        }
        rbl.RepeatDirection = RepeatDirection.Horizontal;
    }
