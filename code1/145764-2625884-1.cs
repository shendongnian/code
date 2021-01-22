    public partial class DistinctLeaves : Window
	{
		public ObservableCollection<GroupItem> Items
		{
			get;
			set;
		}
		public IEnumerable<Group> Groups
		{
			get;
			set;
		}
		public DistinctLeaves()
		{
			Items = new ObservableCollection<GroupItem>();
			Items.Add(new GroupItem("Item A", "Group A"));
			Items.Add(new GroupItem("Item B", "Group A"));
			Items.Add(new GroupItem("Item C", "Group B"));
			Items.Add(new GroupItem("Item D", "Group C"));
			Groups = Items.
				GroupBy(i => i.Group).
				Select(g => new Group(g.Key) { Children = g });
			InitializeComponent();
		}
	}
