    <#@ template language="C#" debug="false" hostspecific="true"#>
    <#@ include file="EF6.Utility.CS.ttinclude"#><#@ 
     output extension=".cs"#><#
    
    const string inputFile = @"Model.edmx";
    var textTransform = DynamicTextTransformation.Create(this);
    var code = new CodeGenerationTools(this);
    var ef = new MetadataTools(this);
    var typeMapper = new TypeMapper(code, ef, textTransform.Errors);
    var	fileManager = EntityFrameworkTemplateFileManager.Create(this);
    var itemCollection = new EdmMetadataLoader(textTransform.Host, textTransform.Errors).CreateEdmItemCollection(inputFile);
    var codeStringGenerator = new CodeStringGenerator(code, typeMapper, ef);
    
    if (!typeMapper.VerifyCaseInsensitiveTypeUniqueness(typeMapper.GetAllGlobalItems(itemCollection), inputFile))
    {
        return string.Empty;
    }
    
    WriteHeader(codeStringGenerator, fileManager);
    
    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
    //START MODIFICATION
    using System.Runtime.Serialization;
    <#=codeStringGenerator.UsingDirectives(inHeader: false)#>
    <#
    	var propertiesWithDefaultValues = typeMapper.GetPropertiesWithDefaultValues(entity);
        var collectionNavigationProperties = typeMapper.GetCollectionNavigationProperties(entity);
        var complexProperties = typeMapper.GetComplexProperties(entity);
    
    	foreach (var navigationProperty in collectionNavigationProperties)
        {
    #>
    [KnownType(typeof(<#=typeMapper.GetTypeName(navigationProperty.ToEndMember.GetEntityType())#>))]
    <#
        }
    #>
    <#=codeStringGenerator.EntityClassOpening(entity)#>
    {
    <#
        if (propertiesWithDefaultValues.Any() || collectionNavigationProperties.Any() || complexProperties.Any())
        {
    #>
        public <#=code.Escape(entity)#>()
        {
    //END MODIFICATION
    <#
            foreach (var edmProperty in propertiesWithDefaultValues)
            {
    #>
            this.<#=code.Escape(edmProperty)#> = <#=typeMapper.CreateLiteral(edmProperty.DefaultValue)#>;
    <#
            }
    
            foreach (var navigationProperty in collectionNavigationProperties)
            {
    #>
            this.<#=code.Escape(navigationProperty)#> = new HashSet<<#=typeMapper.GetTypeName(navigationProperty.ToEndMember.GetEntityType())#>>();
    <#
            }
    
            foreach (var complexProperty in complexProperties)
            {
    #>
            this.<#=code.Escape(complexProperty)#> = new <#=typeMapper.GetTypeName(complexProperty.TypeUsage)#>();
    <#
            }
    #>
        }
