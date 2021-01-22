	public class CustomActions
	{
		[CustomAction]
		public static ActionResult MyAction(Session session)
		{
			if (DialogResult.Yes == MessageBox.Show("Do you want to install desktop shortcut", "Installation", MessageBoxButtons.YesNo))
				session["INSTALLDESKTOPSHORTCUT"] = "yes";
			return ActionResult.Success;
		}
	}
