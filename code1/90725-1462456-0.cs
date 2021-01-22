	public class Frm2 : Form
	{
		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (myDataHasChanged)
			{
				if (dataChanged != null)
					dataChanged();
			}
		}
		private void Close()
		{
			if (myDataHasChanged)
				this.Close();
		}
	}
