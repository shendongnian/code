    public class University : IDisposable
    {
    	private IList<Department> departments = new List<Department>();
    	public void AddDepartment(string name)
    	{
    		//Since the university is in charge of the lifecycle of the
    		//departments, it creates them (composition)
    		departments.Add(new Department(this, name));
    	}
    	public void Dispose()
    	{
    		//destroy the university...
    		//destroy the departments too... (composition)
    		foreach (var department in departments)
    		{
    			department.Dispose();
    		}
    	}
    }
    public class Department : IDisposable
    {
    	//Department makes no sense if it isn't connected to exactly one
    	//University (composition)
    	private University uni;
    	private string name;
    	//list of Professors can be added to, meaning that one professor could
    	//be a member of many departments (aggregation)
    	public IList<Professor> Professors { get; set; }
    	// internal constructor since a Department makes no sense on its own,
    	//we should try to limit how it can be created (composition)
    	internal Department(University uni, string name)
    	{
    		this.uni = uni;
    		this.name = name;
    	}
    	public void Dispose()
    	{
    		//destroy the department, but let the Professors worry about
    		//themselves (aggregation)
    	}
    }
    public class Professor
    {
    }
