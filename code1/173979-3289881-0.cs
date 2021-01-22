    public override void EnumerateItems(FullEnumerationContext context)
    {
        List<ItemFieldDictionary> listItemFieldDictionary = EnumerateItemsCommon();
        context.ReportItems(listItemFieldDictionary);
    }
    
    public void EnumerateItems(IFullEnumerationContext context)
    {
        List<ItemFieldDictionary> listItemFieldDictionary = EnumerateItemsCommon();
        context.ReportItems(listItemFieldDictionary);
    }
