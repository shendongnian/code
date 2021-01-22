    public partial class ThreeLevelTreeView : UserControl
	{
		public ArrayList DeviceGroups { get; private set; }
		public ThreeLevelTreeView()
		{
			DeviceInstance inst1 = new DeviceInstance() { Name = "Instance1" };
			DeviceInstance inst2 = new DeviceInstance() { Name = "Instance2" };
			DeviceInstance inst3 = new DeviceInstance() { Name = "Instance3" };
			DeviceInstance inst4 = new DeviceInstance() { Name = "Instance4" };
			DeviceType type1 = new DeviceType() { Name = "Type1", DeviceInstances = new ArrayList() { inst1, inst2 } };
			DeviceType type2 = new DeviceType() { Name = "Type2", DeviceInstances = new ArrayList() { inst3 } };
			DeviceType type3 = new DeviceType() { Name = "Type3", DeviceInstances = new ArrayList() { inst4 } };
			DeviceType type4 = new DeviceType() { Name = "Type4" };
			DeviceGroup group1 = new DeviceGroup() { Name = "Group1", DeviceTypes = new ArrayList() { type1, type2 } };
			DeviceGroup group2 = new DeviceGroup() { Name = "Group2", DeviceTypes = new ArrayList() { type3, type4 } };
			DeviceGroups = new ArrayList() { group1, group2 };
			InitializeComponent();
		}
	}
	public class DeviceGroup
	{
		public string Name { get; set; }
		public ArrayList DeviceTypes { get; set; }
	}
	public class DeviceType
	{
		public string Name { get; set; }
		public ArrayList DeviceInstances { get; set; }
	}
	public class DeviceInstance
	{
		public string Name { get; set; }
	}
