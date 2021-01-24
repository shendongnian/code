    public class FooModel
    {
        [Required]
        public int Id { get; set; }
    
        [DesignAttribute(Width = 20, BackgroundColor = Constants.RedArgb)]
        public string Name { get; set; }
    }
    
    public static class Constants
    {
        public const int RedArgb = -65536;
    }
