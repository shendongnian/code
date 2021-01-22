    public class GroupItem
	{
		public string Name
		{
			get;
			private set;
		}
		public string Group
		{
			get;
			private set;
		}
		public GroupItem(string name, string group)
		{
			Name = name;
			Group = group;
		}
	}
    public class Group
	{
		public IEnumerable<GroupItem> Children
		{
			get;
			set;
		}
		public string Name
		{
			get;
			private set;
		}
		public Group(string name)
		{
			Name = name;
		}
	}
