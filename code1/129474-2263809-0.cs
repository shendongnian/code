    public class ResourceMap<T> extends Dictionary<string, T> { }
    
    public static class ResourceManager
    {
        public static ResourceMap<Font> Fonts { get; private set; }
        public static ResourceMap<Image> Images { get; private set; }
        public static ResourceMap<Sound> Sounds { get; private set; }
        
        public static void LoadResources()
        {
            Fonts = new ResourceMap<Font>();
            Images = new ResourceMap<Image>();
            Sounds = new ResourceMap<Sound>();
            
            Fonts.Add("Helvetica", new Font("Helvetica", 12, FontStyle.Regular));
            Images.Add("Example", Image.FromFile("example.png"));
        }
    }
