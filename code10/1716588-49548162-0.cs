    public class Project
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(512)]
        [Required]
        public string ProjectName { get; set; }        
        public Category Category{ get; set; }
        [ForeignKey("Category")]
        public Guid? CategoryId{ get; set; }
    
    }
      public class Category
    {
        [Required]
        public Guid Id{ get; set; }
        public string CategoryName{ get; set; }
        public ICollaction<Project> Projects{ get; set; }
    }
    
    var categories = _dbContext.Category.Include(c=>c.Projects).GroupBy(e=>e.CategoryName)
    .Select(e=> new TipoProyectoViewModel(){ CategoryName = e.Key , MProject = e.Key.Projects });
