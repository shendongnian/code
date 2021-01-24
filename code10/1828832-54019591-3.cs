	public partial class Form1 : Form
	{
		class User
		{
			public string StaffId { get; set; }
			public int Total { get; set; }
		}
		public Form1()
		{
			InitializeComponent();
			chart1.Series.Clear();
			
			var series = chart1.Series.Add("Series1");
			series.XValueMember = "StaffId";
			series.YValueMembers = "Total";
			series.Name = "Employee";
			var users = new List<User>();
			users.Add(new User(){StaffId = "John", Total = 70});
			users.Add(new User() { StaffId = "David", Total = 81 });
			users.Add(new User() { StaffId = "Sara", Total = 81 });
			chart1.DataSource = users;
			chart1.DataBind();
			chart1.Show();
		}
		private void chart1_MouseUp(object sender, MouseEventArgs e)
		{
			var pointEndX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
			
			var list = (List<User>)chart1.DataSource;
			//round to the nearest whole number
			pointEndX = Math.Round(pointEndX, 0);
			
			//subtract 1 because bars start at 1 and List/Array are 0 indexed
			int index = ((int)pointEndX )- 1;
			
			if(index <0 || index>=list.Count)
				return;
			var user = list[index];
			MessageBox.Show(user.StaffId);
		}
	}
