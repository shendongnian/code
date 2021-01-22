    using System.Windows.Forms;
	
	public partial class NoSelectionListView : ListView
	{
		public NoSelectionListView()
		{
			InitializeComponent();
		}
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0007) //WM_SETFOCUS
			{
				return;
			}
			base.WndProc(ref m);
		}
	}
