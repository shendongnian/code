		public Form1 ()
		{
			InitializeComponent();
			listView1.Items[0].Selected = false; // Doesn't fire
			listView1.Items[0].Selected = true; // Does fire.
		}
		private void listView1_SelectedIndexChanged (object sender, EventArgs e)
		{
			// code to run
		}
