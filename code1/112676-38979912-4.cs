    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;
    
    namespace ProjectApplicationTemplate
    {
    	public partial class MainForm : Form
    	{
    		public MainForm()
    		{
    			InitializeComponent();
    			OpenFile(Program.GetFileName());
    		}
    
    		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    		protected override void WndProc(ref Message m)
    		{
    			switch (m.Msg)
    			{
    				case Win32.WM_COPYDATA:
    					Win32.CopyDataStruct st = (Win32.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32.CopyDataStruct));
    					string strData = Marshal.PtrToStringUni(st.lpData);
    					OpenFile(strData);
    					Activate();
    					break;
    				default:
    					// let the base class deal with it
    					base.WndProc(ref m);
    					break;
    			}
    		}
    
    		void OpenFile(string filename)
    		{
    			if (filename == "") return;
    			if (!File.Exists(filename)) return;
    			IDocument[] vensters = MdiChildren.Select(T => (IDocument)T).Where(T => T.CurrentFileName == filename).ToArray();
    			if (vensters.Length == 0)
    			{
    				ChildForm frm = new ChildForm();
    				frm.OpenFile(filename);
    				frm.MdiParent = this;
    				frm.Show();
    			}
    			else
    			{
    				vensters[0].Activate();
    			}
    		}
			private void fileMenu_DropDownOpening(object sender, EventArgs e)
			{
				IDocument active = (IDocument)ActiveMdiChild;
				if (active == null)
				{
					saveToolStripMenuItem.Enabled = false;
					saveAsToolStripMenuItem.Enabled = false;
					printToolStripMenuItem.Enabled = false;
					printSetupToolStripMenuItem.Enabled = false;
					printPreviewToolStripMenuItem.Enabled = false;
				}
				else
				{
					saveToolStripMenuItem.Enabled = active.Changed;
					saveAsToolStripMenuItem.Enabled = true;
					printToolStripMenuItem.Enabled = active.CanPrint;
					printSetupToolStripMenuItem.Enabled = active.CanPrint;
					printPreviewToolStripMenuItem.Enabled = active.CanPrint;
				}
				// fill the MRU-list
			
				tmiOnlangsGeopend.DropDownItems.Clear();
				string RecentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
				string[] bestanden = Directory.GetFiles(RecentFolder).Where(T => T.EndsWith(".text.lnk")).ToArray();
				if (bestanden.Length == 0)
				{
					tmiOnlangsGeopend.DropDownItems.Add(new ToolStripMenuItem(Properties.Resources.NoRecent) { Enabled = false });
				}
				else
				{
					foreach (string bestand in bestanden.OrderBy(T => File.GetLastWriteTime(T)).Reverse())
					{
						ToolStripMenuItem tmi = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(bestand.Substring(0, bestand.Length - 4)));
						tmi.Click += delegate { OpenFile(ResolveShortCut(bestand)); };
						tmiOnlangsGeopend.DropDownItems.Add(tmi);
					}
				}
			}
    	}
    }
