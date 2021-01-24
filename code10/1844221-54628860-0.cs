Owner
    public class Owner
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<ProjectOwner> ProjectOwners { get; set; }
    	public ICollection<ProjectProductOwner> ProjectProductOwners { get; set; }
    }
Product
    public class Product
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<ProjectProductOwner> ProjectProductOwners { get; set; }
    }
Project and many-to-many tables
    public class Project
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<ProjectOwner> ProjectOwners { get; set; }
    	public ICollection<ProjectProductOwner> ProjectProductOwners { get; set; }
    
    	public Project()
    	{
    		ProjectOwners = new List<ProjectOwner>();
    		ProjectProductOwners = new List<ProjectProductOwner>();
    	}
    }
    
    public class ProjectOwner
    {
    	public int OwnerId { get; set; }
    	public Owner Owner { get; set; }
    	public int ProjectId { get; set; }
    	public Project Project { get; set; }
    }
    
    public class ProjectProductOwner
    {
    	public int ProductId { get; set; }
    	public Product Product { get; set; }
    	public int OwnerId { get; set; }
    	public Owner Owner { get; set; }
    	public int ProjectId { get; set; }
    	public Project Project { get; set; }
    }
