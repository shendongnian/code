    public partial class MyForm : Form
	{
		public MyForm()
		{
			KeyPreview = true;
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Alt /* AND context menus are open */)
			{
				//Possibly tell your other controls Alt (plus whatever other key(s)) were just pressed
				e.SuppressKeyPress = true;
			}
			base.OnKeyDown(e);
		}
	}
