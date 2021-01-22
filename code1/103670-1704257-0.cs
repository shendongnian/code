    var list = ArticleLedgerEntries.Where(pd => pd.LedgerEntryType == LedgerEntryTypeTypes.Unload
                                       && pd.InventoryType == InventoryTypes.Finished))
    var totalWeight = list.Sum(pd => pd.GrossWeight);
    var totalLength = list.Sum(pd => pd.Length);
    var items = list.Sum(pd => pd.NrDistaff); 
