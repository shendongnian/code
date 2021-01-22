	public class DetectInput : IMessageFilter
	{
		public bool PreFilterMessage(ref Message m)
		{
			if (   m.Msg == (int)WindowsMessages.WM_KEYDOWN 
                || m.Msg == (int)WindowsMessages.WM_MOUSEDOWN  
                // add more input types if you want
                )
			{
				// Do your stuff here
			}
			return false;
		}
	}
