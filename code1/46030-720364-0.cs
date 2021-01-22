	using System;
	using System.Windows.Forms;
	using System.Drawing;
	public class AC : ApplicationContext
	{
		NotifyIcon ni;
		public void menu_Quit(Object sender, EventArgs args)
		{
			ni.Dispose();
			ExitThread();
		}
		public AC()
		{
			ni = new NotifyIcon();
			ni.Icon = SystemIcons.Information;
			ContextMenu menu = new ContextMenu();
			menu.MenuItems.Add("Quit", new EventHandler(menu_Quit));
			ni.ContextMenu = menu;
			ni.Visible = true;
		}
		public static void Main(string[] args)
		{
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			AC ac = new AC();
			Application.Run(ac);		
		}
	}
