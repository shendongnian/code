    private const string xaml = @"
    <UserControl x:Class=""CAL.Modules.Simple.Region_Testing.RegionManagerTypes.XAML.ItemsControlRegionAdapterTest""
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        xmlns:cal=""clr-namespace:Microsoft.Practices.Composite.Presentation.Regions;assembly=Microsoft.Practices.Composite.Presentation""
        Height=""Auto"" Width=""Auto"">
            <ItemsControl cal:RegionManager.RegionName=""ItemsControlRegionAdapterTestRegion""/>
    </UserControl>";
    //in some method
    public void RunMethod()
    {
         //create object and cast it
         ItemsControlRegionAdapterTest obj = (ItemsControlRegionAdapterTest) XamlReader.Parse(xaml);
    }
