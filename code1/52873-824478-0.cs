    class KeyboardMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == ((int)Helper.WindowsMessages.WM_KEYDOWN))
            {
                switch ((int)m.WParam)
                {
                    case (int)Keys.Escape:
                        // Do Something
                        return true;
                    case (int)Keys.Right:
                        // Do Something
                        return true;
                    case (int)Keys.Left:
                        // Do Something
                        return true;
                }
            }
            return false;
        }
    }
