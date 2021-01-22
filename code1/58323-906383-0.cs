			bool haveLock = false;
			try
			{
				lockStream = new System.IO.FileStream(pathToTempFile,System.IO.FileMode.Create,System.IO.FileAccess.ReadWrite,System.IO.FileShare.None);
				haveLock = true;
			}
			catch(Exception)
			{
				System.Console.WriteLine("Failed to acquire lock. ");
			}
			if(!haveLock)
			{
				Inka.Controls.Dialoge.InkaInfoBox diag = new Inka.Controls.Dialoge.InkaInfoBox("App has been started already");
				diag.Size = new Size(diag.Size.Width + 40, diag.Size.Height + 20);
				diag.ShowDialog();
				Application.Exit();
			}
