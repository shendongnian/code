    // Do this once somewhere:
    System.Text.RegularExpressions.Regex insertAndPattern =
        new System.Text.RegularExpressions.Regex("\\)(?=.+$)");
    // And later:
    insertAndPattern.Replace(mystring, ") and ");
