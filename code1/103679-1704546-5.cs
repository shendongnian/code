    // Declare variables in parent scope
    double weight;
    double length;
    int items;
    ArticleLedgerEntries
        .Where(
            pd => 
               pd.LedgerEntryType == LedgerEntryTypeTypes.Unload &&
               pd.InventoryType == InventoryTypes.Finished
        )
        .Each(
            pd => 
            {
                // Close around variables defined in parent scope
                weight += pd.GrossWeight; 
                lenght += pd.Length;
                items += pd.NrDistaff;
            }
        );
