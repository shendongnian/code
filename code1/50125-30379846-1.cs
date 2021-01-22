    public static class ColorBar
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public enum Color { None, Green, Red, Yellow }
        public static void SetState(this ProgressBar pBar, Color newColor, int newValue)
        {
            if (pBar.Value == pBar.Minimum)  // If it has not been painted yet, paint the whole thing using defualt color...
            {                                // Max move is instant and this keeps the initial move from going out slowly 
                pBar.Value = pBar.Maximum;   // in wrong color on first painting
                SendMessage(pBar.Handle, 1040, (IntPtr)(int)Color.Green, IntPtr.Zero);
            }
            pBar.Value = newValue;
            SendMessage(pBar.Handle, 1040, (IntPtr)(int)Color.Green, IntPtr.Zero);     // run it out to the correct spot in default
            SendMessage(pBar.Handle, 1040, (IntPtr)(int)newColor, IntPtr.Zero);        // now turn it the correct color
        }
    }
