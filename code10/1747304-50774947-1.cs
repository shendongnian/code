    public class ModelDto
    {
        public string Name { get; set; }
        public ModelType ModelType { get; set; }
    }
    public enum ModelType
    {
        One = 1,
        Two = 2
    }
