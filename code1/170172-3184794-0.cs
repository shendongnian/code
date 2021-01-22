    /// <summary>The employee structure with explicit conversion to a TreeNode (you may also use implicit conversion, but i prefer explicit).</summary>
    public struct Employee
    {
    	public int Id;
    	public string Name;
    	public int BossId;
    
    	public static explicit operator TreeNode(Employee e) { return new TreeNode(e.Name); }
    }
    
    public static class EmployeesExtension
    {
    	/// <summary>More abstract and readable way to add an employee.</summary>
    	public static void Add(this Dictionary<int, List<Employee>> employees, int id, string name, int bossId)
    	{
    		if (!employees.ContainsKey(bossId)) employees[bossId] = new List<Employee>();
    
    		employees[bossId].Add(new Employee() { Id = id, Name = name, BossId = bossId });
    	}
    }
