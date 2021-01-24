		public FinalScreen()
		{
			InitializeComponent();
 		}
		public FinalScreen(string checkedSymptoms)
			:base()
		{
			InitializeComponent();
			CheckedSymptoms = checkedSymptoms;
		}
		public string CheckedSymptoms { get; set; }
		private void FinalScreen_Load(object sender, EventArgs e)
		{
			label1.Text = CheckedSymptoms;
		}
