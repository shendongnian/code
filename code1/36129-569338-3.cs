    public class KeyDownMessageFilter : IMessageFilter
    {
        public const int WM_KEYDOWN = 0x0100;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                // Key Down
                return true; // Event handled
            }
            return false;
        }
    }
