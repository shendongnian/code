    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace DataUploader
    {
    		static class Program
		{
			[STAThread]
			static void Main()
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				NotifyIcon icn = new NotifyIcon();
				icn.Click += new EventHandler(icn_Click);
				icn.Visible = true;
				icn.Icon = new System.Drawing.Icon(@”SomeIcon.ico”);
				Application.Run();
			}
			
			static void icn_Click(object sender, EventArgs e)
			{
				Application.Exit();
			}
		}
    }
