    public class Item
    {
        public int Version { get; set; }
        public int SchemaVersion { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Artist { get; set; }
        public string ArtistLocalized { get; set; }
        public string ArtistSource { get; set; }
        public string Illustrator { get; set; }
        public string IllustratorSource { get; set; }
        public string Charter { get; set; }
        public ItemMusic Music { get; set; }
        public ItemMusicPreview MusicPreview { get; set; }
        public ItemBackground Background { get; set; }
        public List<ItemChart> Charts { get; set; }
    }
    public class ItemMusic
    {
        public string Path { get; set; }
    }
    public class ItemMusicPreview
    {
        public string Path { get; set; }
    }
    public class ItemBackground
    {
        public string Path { get; set; }
    }
    public class ItemChart
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Path { get; set; }
    }
