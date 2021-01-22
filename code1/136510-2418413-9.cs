    // define a general-purpose settings interface, i do not much
    // care for refactor tools, but you may use re-sharper or built in
    // refactor components to "extract" those properties from global
    // settings that you need. here we pull out culture name only,
    public interface ISettings
    {
        // gets culture name from underlying settings implementation
        string CultureName { get; }
    }
    public class LocalizedContent
    {
        public string CultureName { get; set; }
        public LocalizedContent (ISettings settings)
        {
            CultureName = settings.CultureName;
        }
    }
