	public class MainForm : Form
	{
		public bool ProcessCmdKeyFromChildForm(ref Message msg, Keys keyData)
		{
			Message messageCopy = msg;
			messageCopy.HWnd = this.Handle; // We need to assign our own Handle, otherwise the message is rejected!
			return ProcessCmdKey(ref messageCopy, keyData);
		}
	}
	public class MyChildForm : Form
	{
		private MainForm mMainForm;
		public MyChildForm(MainForm mainForm)
		{
			mMainForm = mainForm;
		}
		// This is meant to forward accelerator keys (eg. Ctrl-Z) to the MainForm
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (mMainForm.ProcessCmdKeyFromChildForm(ref msg, keyData))
			{
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
