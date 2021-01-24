    SLDocument sl = new SLDocument();
    
    SLStyle style1 = sl.CreateStyle();
    style1.Fill.SetPattern(PatternValues.Solid, SLThemeColorIndexValues.Accent2Color, SLThemeColorIndexValues.Accent4Color);
    
    // set row 4 with 1st style
    sl.SetRowStyle(4, style1);
    sl.SaveAs("StyleRowColumnCell.xlsx");
