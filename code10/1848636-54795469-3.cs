    static void Main()
    {
        //...SNIP...
	    Application.AddMessageFilter(new AltFilter());
        //...SNIP...
	}
    public class AltFilter : IMessageFilter
	{
		private static ushort WM_SYSKEYDOWN = 0x0104;
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == WM_SYSKEYDOWN && Control.ModifierKeys == Keys.Alt)
			{
				//Do your own special thing instead
				return true;
			}
			return false;
		}
	}
