    Worksheet sheet = (Worksheet)this.Application.ActiveSheet;
    Range usedRange = sheet.UsedRange;
    bool isUsed = (usedRange.Count > 1);
    if (usedRange.Count == 1)
    {
      isUsed = (usedRange.Value2 != null) &&
               (!string.IsNullOrEmpty(usedRange.Value2.ToString()));
    }
    
    if(isUsed)
    {
      // worksheet cells not empty
    }
