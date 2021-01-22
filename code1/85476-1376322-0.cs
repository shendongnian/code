	public class Form : System.Windows.Forms.Form
	{
		protected override void DestroyHandle()
		{
			lock (this) base.DestroyHandle();
		}
	}
