    public static class LocaleHelper
    {
        public static T GetRessource<T>(Ressource<T> Source)
        {
            return default(T);
        }
    }
    public class Ressource<T>
    {
        public T DefaultValue { get; set; }
    }
