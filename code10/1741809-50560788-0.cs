    public class PersonalList
    {
    	public List<ListMember> ListMembers { get; set; }
    	public long ListNumber { get; set; }
    	public string Description { get; set; }
    }
    
    public class ListMember
    {
    	public string MemberName { get; set; }
    	public long ListId { get; set; }
    	public string MemberType { get; set; }
    	public string Position { get; set; }
    }
    
    static void Main(string[] args)
    {
    	List<PersonalList> _allPersonalLists = new List<PersonalList>();
    
    	for (int i = 1; i <= 5; i++)
    	{
    		List<ListMember> ListMembers = new List<ListMember>();
    		for (int j = 1; j <= 3; j++)
    		    ListMembers.Add(new ListMember() { ListId = j, MemberName = "Member" + i + j, MemberType = "Type" + i, Position = "Position" + i });
    
    		_allPersonalLists.Add(new PersonalList() { ListNumber = i, ListMembers = ListMembers, Description = "Desc" + i });
    	}
    
    	var personalLists = _allPersonalLists.ToDictionary(x => x.ListNumber, x => x.ListMembers.Select(y => new { y.MemberName, y.MemberType }).ToList());
    
    	Console.ReadLine();
    }
