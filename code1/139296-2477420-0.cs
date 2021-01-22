    static class Helper
    {
        public static void SetCheckProgrammatically(
            this CheckBox c, 
            EventHandler subscribedEvent, bool b)
        {            
            c.CheckedChanged -= subscribedEvent; // unsubscribe
            c.Checked = b;
            c.CheckedChanged += subscribedEvent; // subscribe
        }
    }
