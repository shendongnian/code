        public static void ControlClear<type>(Control.ControlCollection controls) where type : Control
        {
            foreach (Control c in controls)
                if (c is type)
                    ((type)c).Text = "";
        }
//===============
       ControlClear<TextBox>(Controls);
