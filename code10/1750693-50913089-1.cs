    List<StandardLookUpList> _AnalsisCodes = GetAnayalsisCodesForExportCode();
    var codesForThisItem = _AnalsisCodes.Where(w => w.ItemCode == item.ItemCode);
    
    if (codesForThisItem.Any())
    {
         sport = codesForThisItem.FirstOrDefault(x => x.code == Constants.Sport);
         gender = codesForThisItem.FirstOrDefault(x => x.code == Constants.Gender); 
    }
