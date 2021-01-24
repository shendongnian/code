        public class Department
        {        
        [Key]
        public int DepartmentId { get; set; }          
        public int? ParentId { get; set; }       
        public Department Parent { get; set; }          
        public ICollection<Department> Children { get; set; }
        public string Title { get; set; }
        }
