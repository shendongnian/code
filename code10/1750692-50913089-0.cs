    List<StandardLookUpList> _AnalsisCodes = GetAnayalsisCodesForExportCode();
    var codesForThisItem = _AnalsisCodes.Where(w => w.ItemCode == item.ItemCode);
    
    if (codesForThisItem.Any())
    {
         var sportResult = codesForThisItem.FirstOrDefault(x => x.code == Constants.Sport);
         if (sportResult != null) sport = sportResult;
    
         var genderResult = codesForThisItem.FirstOrDefault(x => x.code == Constants.Gender); 
         if (genderResult != null) gender = genderResult;
    }
