	public class MainForm : Form
	{
		private HeaderClass HeaderClass;
		public MainForm()
		{
			HeaderClass = new HeaderClass(this);
		}
	}
	public class HeaderClass
	{
		private MainForm MainForm;
		public HeaderClass(MainForm mainForm)
		{
			MainForm = mainForm;
		}
		
		public void MethodThatYouNeedToCloseTheFormFrom()
		{
			...
			MainForm.Close();
			...
		}
	}
