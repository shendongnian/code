	static void ShowUnhandledException(object sender, ThreadExceptionEventArgs t)
	{
		Exception ex = t.Exception;
		try {
			// Build a message to show to the user
			bool first = true;
			string msg = string.Empty;
			for (int i = 0; i < 3 && ex != null; i++) {
				msg += string.Format("{0} {1}:\n\n{2}\n\n{3}", 
					first ? "Unhandled " : "Inner exception ",
					ex.GetType().Name,
					ex.Message, 
					i < 2 ? ex.StackTrace : "");
				ex = ex.InnerException;
				first = false;
			}
			msg += "\n\nAttempt to continue? (click No to exit now)";
			
			// Show the message
			if (MessageBox.Show(msg, "Unhandled exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
				Application.Exit();
		} catch (Exception e2) {
			try {
				MessageBox.Show(e2.Message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			} finally {
				Application.Exit();
			}
		}
	}
