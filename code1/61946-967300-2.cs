    internal static class ControlHelper
    {
        private static bool IsGotLostFocusControl(Control ctl)
        {
            return ctl.GetType().IsSubclassOf(typeof(TextBoxBase)) ||
               (ctl.GetType() == typeof(ComboBox) && (ctl as ComboBox).DropDownStyle == ComboBoxStyle.DropDown);
        }
    
        public static void AttachGotLostFocusEvents(
            System.Windows.Forms.Control.ControlCollection controls,
            EventHandler gotFocusEventHandler,
            EventHandler lostFocusEventHandler)
        {
            foreach (Control ctl in controls)
            {
                if (IsGotLostFocusControl(ctl))
                {
                    ctl.GotFocus += gotFocusEventHandler;
                    ctl.LostFocus += lostFocusEventHandler ;
                }
                else if (ctl.Controls.Count > 0)
                {
                    AttachGotLostFocusEvents(ctl.Controls, gotFocusEventHandler, lostFocusEventHandler);
                }
            }
        }
    
        public static void DetachGotLostFocusEvents(
            System.Windows.Forms.Control.ControlCollection controls,
            EventHandler gotFocusEventHandler,
            EventHandler lostFocusEventHandler)
        {
            foreach (Control ctl in controls)
            {
                if (IsGotLostFocusControl(ctl))
                {
                    ctl.GotFocus -= gotFocusEventHandler;
                    ctl.LostFocus -= lostFocusEventHandler;
                }
                else if (ctl.Controls.Count > 0)
                {
                    DetachGotLostFocusEvents(ctl.Controls, gotFocusEventHandler, lostFocusEventHandler);
                }
            }
        }
    }
