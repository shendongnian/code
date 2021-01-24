    ResourceDictionary dict = new ResourceDictionary();
    try
    {
        dict.Source = new Uri("/Emdep.Geos.UI.Common;component/Resources/Language." + lan + ".xaml", UriKind.RelativeOrAbsolute);
    }
    catch (FileNotFoundException)
    {
        //the resource dictionary could not be located/loaded...
    }
