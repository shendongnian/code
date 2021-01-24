    public class IconCollection : Collection<Icon> {
        //Customize here
    }
    
    public class ManifestModel
    {
        //
        public IconCollection Icons { get; } = new IconCollection();
        //...
    }
