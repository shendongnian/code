	public Form1()
	{
		InitializeComponent();
		comboBox1.DataSource = new List<MyObj>()
		{
			new MyObj(){Name = "Fish",MyInt = 3,MyIntPtr = new IntPtr(5),MyIntPtr2 = new IntPtr(7)}
		};
		
		comboBox1.DisplayMember = "Name";
		comboBox1.ValueMember = "MyIntPtr";
		comboBox1.ValueMember = "MyIntPtr2";
		comboBox1.SelectedIndexChanged += (s, e) => { MessageBox.Show("Selected:" + comboBox1.SelectedValue); };
	}
	private class MyObj
	{
		public string Name { get; set; }
		public int MyInt { get; set; }
		public IntPtr MyIntPtr { get; set; }
		[System.ComponentModel.Browsable(false)]
		public IntPtr MyIntPtr2 { get; set; }
	}
