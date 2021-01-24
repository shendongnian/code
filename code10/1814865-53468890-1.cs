    public class MembersController : ApiController
    {
    	List<Member> members = new List<Member>();
    	public MembersController()
    	{
    	    var member1 = new Member { memberNumber = 1234567890, forename = "Fred", surname = "Smith"};
    		var member2 = new Member { memberNumber = 1, forename = "Big", surname = "Ben"};
    		var member3 = new Member { memberNumber = 2, forename = "Jack", surname = "Ryan" };
    		member1.products.Add(new Products { name = "Health Ins", cost = 100 });
    		member1.products.Add(new Products { name = "Travel Ins", cost = 150 });
    		
    		members.Add(member1);
    		members.Add(member2);
    		members.Add(member3);
    	}
    	// GET: api/Members
    	public List<Member> Get()
    	{
    		return members;
    	}
    
    	// GET: api/Members/5
    	public Member Get(int id)
    	{
    		return members.Where(x => x.memberNumber == id).FirstOrDefault();
    	}
    }
