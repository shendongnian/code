    public partial class Window1 : Window
	{
		public ObservableCollection<IFruit> Fruits { get; set; }
		public Window1()
		{
			InitializeComponent();
			Fruits = new ObservableCollection<IFruit>();
			Fruits.Add(new Apple { AppleType = "Granny Smith", HasWorms = false });
			Fruits.Add(new Orange { OrangeType = "Florida Orange", VitaminCContent = 75 });
			Fruits.Add(new Apple { AppleType = "Red Delicious", HasWorms = true });
			Fruits.Add(new Orange { OrangeType = "Navel Orange", VitaminCContent = 130 });
			this.DataContext = this;
		}
	}
	public interface IFruit
	{
		string Name { get; }
		string Color { get; }
	}
	public class Apple : IFruit
	{
		public Apple() { }
		public string AppleType { get; set; }
		public bool HasWorms { get; set; }
		#region IFruit Members
		public string Name { get { return "Apple"; } }
		public string Color { get { return "Red"; } }
		#endregion
	}
	public class Orange : IFruit
	{
		public Orange() { }
		public string OrangeType { get; set; }
		public int VitaminCContent { get; set; }
		#region IFruit Members
		public string Name { get { return "Orange"; } }
		public string Color { get { return "Orange"; } }
		#endregion
	}
