    public interface IThemeResource
    {
        public string Name { get; }
        public string Description { get; }
        public string TypeName { get; }
    }
    
    public class ThemeResource<T> : IThemeResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get { return typeof(T); } }
        public string TypeName { get { return Type.FullName; } }
        public T Resource { get { return (T)Application.Current.Resources[this.Name]; } }
    }
