     public class Furniture
    {
        public int Id { get; set; }
        public string FurName { get; set; }
        public FurnitureType FurnitureType { get; set; }
    }
    public enum FurnitureType
    {
        bed,
        couch,
        table
    }
