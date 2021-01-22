    public class MyFilterClass : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
                // Check if mouse is over my picture box!
            return false;
        }
    }
