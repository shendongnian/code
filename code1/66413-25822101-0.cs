		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				litMessage.Visible = true;
				System.Diagnostics.Process oProcess = null;
				try
				{
					string strRootRelativePathName = "~/Application.exe";
					string strPathName =
						Server.MapPath(strRootRelativePathName);
					if (System.IO.File.Exists(strPathName) == false)
					{
						litMessage.Text = "Error: File Not Found!";
					}
					else
					{
						oProcess =
							new System.Diagnostics.Process();
						oProcess.StartInfo.Arguments = "args";
						oProcess.StartInfo.FileName = strPathName;
						oProcess.Start();
						oProcess.WaitForExit();
						System.Threading.Thread.Sleep(20000);
						litMessage.Text = "Application Executed Successfully...";
					}
				}
				catch (System.Exception ex)
				{
					litMessage.Text =
						string.Format("Error: {0}", ex.Message);
				}
				finally
				{
					if (oProcess != null)
					{
						oProcess.Close();
						oProcess.Dispose();
						oProcess = null;
					}
				}
			}
		}
