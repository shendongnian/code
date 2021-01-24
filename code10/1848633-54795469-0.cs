    public partial class MyContextMenuStrip : ContextMenuStrip
	{
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Alt)
				return true;
			return base.ProcessDialogKey(keyData);
		}
	}
