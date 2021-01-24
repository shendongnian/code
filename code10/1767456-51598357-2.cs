    [ModelBinder(BinderType = typeof(PostModelBinder))]
    public class PostModel
    {
        public int Id { get; set; }
    
        public Category? Category { get; set; }
    }
