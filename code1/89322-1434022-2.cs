    string[] level = {"Expert", "Proficient", "Limited Experience", "No Experience"};
    string[] language = { "CSharp", "VbNet", "VbClassic", "Crystal", "Ssrs", "Sql2005", "UiWeb" };
    foreach (string lang in language)
    {
        RadioButtonList rbl = (RadioButtonList)FindControl("rbl" + lang);
        if (rbl == null)
            continue;  // keep going through the rest, or throw exception
    
        rbl.Items.Clear();
        // this could be a foreach instead, but I kept your original code
        for (int i = 0; i < level.GetLength(0); i++)
        {
            rbl.Items.Add(level[i]);
        }
        rbl.RepeatDirection = RepeatDirection.Horizontal;
    }
