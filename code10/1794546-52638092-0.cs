    public class AViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BViewModel myB { get; set; }
    }
    public class BViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AViewModel> As { get; set; }
    }
