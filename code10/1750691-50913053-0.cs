    List<StandardLookUpList > _AnalsisCodes = GetAnayalsisCodesForExportCode();
    var codesForThisItem = _AnalsisCodes.Where(w => w.ItemCode == item.ItemCode);
    if (codesForThisItem.Any())
    {
    	if (codesForThisItem.FirstOrDefault(x => x.code == Constants.Sport) != null)
    	{
    		sport = codesForThisItem.First(x => x.code == Constants.Sport);
    	}
    
    	if (codesForThisItem.FirstOrDefault(x => x.code == Constants.Gender) != null)
    	{
    		gender = codesForThisItem.First(x => x.code == Constants.Gender);
    	}
    }
