	void Main()
	{
		var posts = 
			new List<Post>() 
			{
				new Post {PostId = 1, PostType = "news"},
				new Post {PostId = 2, PostType = "old"},
				new Post {PostId = 3, PostType = "news"},
			};
			
		var owners = 
			new List<OwnerGroup>()
			{
				new OwnerGroup {GroupId = 1, PostId = 1, OwnerName = "Group A" },
				new OwnerGroup {GroupId = 2, PostId = 1, OwnerName = "Group A" },
				new OwnerGroup {GroupId = 3, PostId = 2, OwnerName = "Group A" },
			};
	
		var leftJoinResult = posts
			.GroupJoin(
				owners.Where(o => o.OwnerName.Equals("Group A")), 
				r => r.PostId, rp => rp.PostId, 
				(l1, l2) => new { gjl1 = l1, gjl2 = l2 })
			.SelectMany(x => x.gjl2.DefaultIfEmpty(), (x, gjl2) => new { x.gjl1, gjl2 })
			.Where(x => x.gjl1.PostType.Equals("news") )
			// OPTIONAL: Add this line return the Post matches, not both the Post and the possible left joined OwnerGroup
			.Select(x => x.gjl1) 
			// OPTIONAL: Add this line to only get the distinct Post matches
			.GroupBy(p => p.PostId).Select(grp => grp.First());
	}
	
	public class Post
	{
		public int PostId { get; set; }
		public string PostType { get; set; }
	}
	
	public class OwnerGroup
	{
		public int GroupId { get;set; }
		public int PostId { get; set; }
		public String OwnerName { get; set; }
	}
