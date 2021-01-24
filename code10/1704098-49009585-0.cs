    public class OpeningTimes
    {
        public OpeningGeneral General { get; set; }
        public Dictionary<string, Alteration[]> Alterations { get; set; }
    }
    public class Alteration
    {
        public string Opens { get; set; }
        public string Closes { get; set; }
    }
