    public partial class RefusjonsOppgjorGrid : DataGridView
	{
		public RefusjonsOppgjorGrid()
		{
			InitializeComponent();
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataGridViewColumnCollection Columns
		{
			get{ return base.Columns;}
		}
	}
