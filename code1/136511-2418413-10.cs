    // public singleton is now an implementation of a "loosely coupled
    // component" called ISettings
    public class GlobalSettings : ISettings { ... }
    // elsewhere in code
    public LocalizedContent GetLocalizedContent ()
    {
        LocalizedContent content = new LocalizedContent (GlobalSettings.Instance);
        return content;
    }
