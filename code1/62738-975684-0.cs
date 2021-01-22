    [ActiveRecord("Forms")]
    public class SmartForm : Item
    {
        [PrimaryKey("Id")]
        public string IdCode { get; set; }
        [Property]
        public string Title { get; set; }
        [Property]
        public string Description { get; set; }
        [Property]
        public int LabelWidth { get; set; }
    }
