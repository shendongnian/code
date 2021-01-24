    public class ModelClass
    {
        public Guid Id { get; set; }
        public ChildModel ChildModel { get; set; }
    }
    public class ViewModelClass
    {
        public Guid Id { get; set; }
        public ChildModel ChildModel { get; set; } = new ChildModel();
    }
    public class ChildModel
    {
        public Guid Id { get; set; }
    }
