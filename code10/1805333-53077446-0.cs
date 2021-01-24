    public class ProductionPersonRole
    {
    	public int ProductionId { get; set; }
    	public int PersonId { get; set; }
    	public int RoleId { get; set; }
    	public Production Production { get; set; }
    	public Person Person { get; set; }
    	public Role Role { get; set; }
    }
