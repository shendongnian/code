    public class Category 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int? ParentId { get; set; }
    
        public virtual Category Parent { get; set; }
    
        public virtual ICollection<Category> Children { get; set; }
    	
    	private IList<Category> allParentsList = new List<Category>();
    	
    	public IEnumerable<Category> AllParents()
        {
            var parent = Parent;
            while (!(parent is null))
            {
                allParentsList.Add(parent);
                parent = parent.Parent;
            }
            return allParentsList;
        }
    
        public IEnumerable<Category> AllChildren()
        {
            yield return this;
            foreach (var child in Children)
            foreach (var granChild in child.AllChildren())
            {
                yield return granChild;
            }
        }	
    }
