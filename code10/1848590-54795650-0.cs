	void Main()
	{
		var data = GetData();
			
		Console.WriteLine(GetPath(data, 23, ""));
	}
	
	public String GetPath(Categories c, Int32 id, String path)
	{	
		if (c.Id == id)
		{
			return path + "/" + c.Name;
		}
		
		foreach (var cd in c.ChildrenData)
		{
			var p = GetPath(cd, id, path + "/" + c.Name);
			if (!String.IsNullOrWhiteSpace(p))
			{
				return p;
			}
		}
		return "";
	}
	
	public class Categories
	{
		public long Id { get; set; }
	
		public long ParentId { get; set; }
	
		public string Name { get; set; }
	
		public bool IsActive { get; set; }
	
		public List<Categories> ChildrenData { get; set; }
	}
	
	public Categories GetData()
	{
		return
			new Categories
			{
				Id = 1,
				Name = "Default Category",
				ChildrenData = new List<Categories>
				{
						new Categories
						{
							Id = 2,
							Name = "Magazines",
							ChildrenData = new List<Categories> {}
						},
						new Categories
						{
							Id = 2,
							Name = "Books",
							ChildrenData = new List<Categories>
							{
								new Categories
								{
									Id = 20,
									Name = "Fiction",
									ChildrenData = new List<Categories> {}
								},
								new Categories
								{
									Id = 21,
									Name = "Nonfiction",
									ChildrenData = new List<Categories>
									{
										new Categories
										{
											Id = 22,
											Name = "New",
											ChildrenData = new List<Categories> {}
										},
										new Categories
										{
											Id = 23,
											Name = "Best-Sellers",
											ChildrenData = new List<Categories> {}
										},
									}
								}
	
	
							}
						}
				}
			};
	}
