    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
    <#=codeStringGenerator.UsingDirectives(inHeader: false)#> // This may be slightly different based on version of EF, but you get the idea
    <#=codeStringGenerator.EntityClassOpening(entity)#>
    {
    <#
        var propertiesWithDefaultValues = typeMapper.GetPropertiesWithDefaultValues(entity);
        var collectionNavigationProperties = typeMapper.GetCollectionNavigationProperties(entity);
        var complexProperties = typeMapper.GetComplexProperties(entity);
    
        if (propertiesWithDefaultValues.Any() || collectionNavigationProperties.Any() || complexProperties.Any())
        {
    #>
        public <#=code.Escape(entity)#>()
        {
    // ... much later
            foreach (var complexProperty in complexProperties)
            {
    #>
            this.<#=code.Escape(complexProperty)#> = new <#=typeMapper.GetTypeName(complexProperty.TypeUsage)#>();
    <#
            }
    #>
        }
        Init();
    }
    partial void Init();
