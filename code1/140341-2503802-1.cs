		private List<Tuple<DateTime, int>> items = new List<Tuple<DateTime, int>>()
		{
			new Tuple<DateTime, int>(new DateTime(2010, 1, 1), 3),
			new Tuple<DateTime, int>(new DateTime(2010, 2, 1), 4),
			new Tuple<DateTime, int>(new DateTime(2010, 4, 1), 2),
			new Tuple<DateTime, int>(new DateTime(2010, 5, 1), 2),
			new Tuple<DateTime, int>(new DateTime(2010, 8, 1), 3),
			new Tuple<DateTime, int>(new DateTime(2010, 9, 1), -3),
			new Tuple<DateTime, int>(new DateTime(2010, 10, 1), 6),
			new Tuple<DateTime, int>(new DateTime(2010, 11, 1), 3),
			new Tuple<DateTime, int>(new DateTime(2010, 12, 1), 7),
			new Tuple<DateTime, int>(new DateTime(2011, 2, 1), 3)
		};
		public Form1()
		{
			InitializeComponent();
			var list = items.FillMissing();
			foreach(var element in list)
			{
				textBox1.Text += Environment.NewLine + element.Item1.ToString() + " - " + element.Item2.ToString();
			}
		}
