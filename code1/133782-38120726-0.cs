     public class FocusableUserControl : UserControl
     {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)Win32Constants.WM_SETFOCUS:
                //Returning from here will skip setting focus to child controls.
                //It will not skip setting focus to this control.
                
                    Console.WriteLine("FocusableUserControl is focused: " + Focused);
                    return;
            }
            base.WndProc(ref m);
        }
    }
