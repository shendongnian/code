            // MISSING
            // Creating the UserControl in CODE instead of XAML
            var obj = (UserControl)XamlReader.Parse(@"<UserControl xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                                                   xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:cal=""clr-namespace:Microsoft.Practices.Composite.Presentation.Regions;assembly=Microsoft.Practices.Composite.Presentation""
    Height=""Auto"" Width=""Auto"">
        <ItemsControl cal:RegionManager.RegionName=""ItemsControlRegionAdapterTestRegion""/></UserControl>");
            
            // Create the UserControl and add it to the main window
            regionManager.AddToRegion(RegionNames.MainRegion, obj);
