    		private bool visible = false;
		public bool Visible
		{
			get
			{
				return visible;
			}
			set
			{
				visible = value;
			}
		}
		private int fakeVisible
		{
			get
			{
				return 0;
			}
			set
			{
				visible = value > 0;
			}
		}
		[Column(Name="Visible", Storage = "fakeVisible", DbType = "Int NOT NULL")]
		public int FakeVisible { get; set; }
