    void Main()
    {
    	var dataStructure = Init_DataStructure();
    
    	List<int> members = GetMembers(dataStructure).ToList();
    }
    
    IEnumerable<int> GetMembers(Class1 input)
    {
    	yield return input.Member;
    
    	foreach (var subMember in input.MemberList.SelectMany(c => GetMembers(c)))
    		yield return subMember;
    }
    
    Class1 Init_DataStructure()
    {
    	Class1
    		a1 = new Class1
    		{
    			Id = "A1",
    			Member = 1,
    			MemberList = new Collection<Class1>()
    		},
    		a11 = new Class1
    		{
    			Id = "A11",
    			Member = 2,
    			Parent = a1
    		};
    	a1.MemberList.Add(a11);
    
    	Class1
    		a2 = new Class1
    		{
    			Id = "A2",
    			Member = 3,
    			MemberList = new Collection<Class1>()
    		},
    		a21 = new Class1
    		{
    			Id = "A21",
    			Member = 4,
    			Parent = a2
    		};
    	a2.MemberList.Add(a21);
    
    	return new Class1
    	{
    		Id = "A",
    		Member = 0,
    		MemberList = new Collection<Class1> { a1, a2 }
    	};
    }
    
    class Class1
    {
    	public Class1() => MemberList = new Collection<Class1>();
    
    	public Class1 Parent { get; set; }
    
    	public string Id { get; set; }
    	public int Member { get; set; }
    
    	public ICollection<Class1> MemberList { get; set; }
    }
