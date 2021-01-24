	public class Manager
	{
		public int Id { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
	}
	
	public class Project
	{
		public int Id { get; set; }
		
		public virtual ICollection<Document> Documents { get; set; }
		
		public virtual Manager Manager { get; set; }
		public int ManagerId { get; set; }
	}
	
	public class Document
	{
		public int Id { get; set; }
		public virtual Project Project { get; set; }
		public int ProjectId { get; set; }
	}
