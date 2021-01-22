    ArticleLedgerEntries
        .Where(
            pd => 
               pd.LedgerEntryType == LedgerEntryTypeTypes.Unload &&
               pd.InventoryType == InventoryTypes.Finished
        )
        .Each(
            pd => 
            {
                weight += pd.GrossWeight; 
                lenght += pd.Length;
                items += pd.NrDistaff;
            }
        );
