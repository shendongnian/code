    public class ParentItemDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string SomeInfo { get; set; }
        public List<ChildItemDataModel> Children { get; set; }
    }
    public class ChildItemDataModel
    {
        public ParentItemDataModel Parent { get; set; }
        public string SomeInfo { get; set; }
    }
