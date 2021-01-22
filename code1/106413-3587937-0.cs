    foreach (Excel.Name name in Globals.ThisWorkbook.Name)
    {
    if (Application.Intersect(name.RefersToRange, Target) != Null) //Target is the single parameter of our handler delegate type.
    {
    // FOUND IT!!!!
    }
    }
