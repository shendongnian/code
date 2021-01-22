	public class MyFormBase : System.Windows.Forms.Form
	{
		private MyWaitForm _waitForm;
		protected void ShowWaitForm(string message)
		{
			_waitForm = new MyWaitForm();
			_waitForm.SetLabel("Loading data. Please wait . . . ");
			_waitForm.TopMost = true;
			_waitForm.StartPosition = FormStartPosition.CenterScreen;
			_waitForm.Show();
			_waitForm.Refresh();
			// force the wait window to display for at least 700ms so it doesn't just flash on the screen
			System.Threading.Thread.Sleep(700);			
			Application.Idle += OnLoaded;
		}
		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= OnLoaded;
			_waitForm.Close();
		}
	}
