    public static Dictionary<TKey1, Dictionary<TKey2, TValue>> Pivot3<TSource, TKey1, TKey2, TValue>(
    	this IEnumerable<TSource> source
    	, Func<TSource, TKey1> key1Selector
    	, Func<TSource, TKey2> key2Selector
    	, Func<IEnumerable<TSource>, TValue> aggregate)
    {
    	return source.GroupBy(key1Selector).Select(
    		x => new
    		{
    			X = x.Key,
    			Y = source.GroupBy(key2Selector).Select(
    				z => new
    				{
    					Z = z.Key,
    					V = aggregate(from item in source
    								  where key1Selector(item).Equals(x.Key)
    								  && key2Selector(item).Equals(z.Key)
    								  select item
    					)
    
    				}
    			).ToDictionary(e => e.Z, o => o.V)
    		}
    	).ToDictionary(e => e.X, o => o.Y);
    } 
    internal class Employee
    {
    	public string Name { get; set; }
    	public string Department { get; set; }
    	public string Function { get; set; }
    	public decimal Salary { get; set; }
    }
    public void TestLinqExtenions()
    {
    	var l = new List<Employee>() {
    	new Employee() { Name = "Fons", Department = "R&D", Function = "Trainer", Salary = 2000 },
    	new Employee() { Name = "Jim", Department = "R&D", Function = "Trainer", Salary = 3000 },
    	new Employee() { Name = "Ellen", Department = "Dev", Function = "Developer", Salary = 4000 },
    	new Employee() { Name = "Mike", Department = "Dev", Function = "Consultant", Salary = 5000 },
    	new Employee() { Name = "Jack", Department = "R&D", Function = "Developer", Salary = 6000 },
    	new Employee() { Name = "Demy", Department = "Dev", Function = "Consultant", Salary = 2000 }};
    
    	var result5 = l.Pivot3(emp => emp.Department, emp2 => emp2.Function, lst => lst.Sum(emp => emp.Salary));
    	var result6 = l.Pivot3(emp => emp.Function, emp2 => emp2.Department, lst => lst.Count());
    }
