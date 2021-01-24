    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    namespace DomainModel
    {
        public class Category
        {
            public Category()
            {
                Children = new HashSet<Category>();
            }
    
            public int Id { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            public int? ParentId { get; set; }
    
            public virtual ICollection<Category> Children { get; set; }
    
            public virtual Category Category1 { get; set; }
        }
    }
