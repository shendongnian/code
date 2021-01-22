    public class YourEntity
    {
       public int ID { get; set; }
       public string Name{ get; set; }
       public string Description { get; set; }
       public OptionType Types { get; set; }
    }
    public enum OptionType
    {
        Unknown,
        Option1, 
        Option2,
        Option3
    }
