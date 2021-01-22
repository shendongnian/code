    public static class extenstions
    {
        private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() { 
                {typeof(TextBox), c => ((TextBox)c).Clear()},
                {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
                {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
                {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
                {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
                {typeof(Panel), c => ((Panel)c).Controls.ClearControls()}
        };
        private static void FindAndInvoke(Type type, Control control) 
        {
            if (controldefaults.ContainsKey(type)) {
                controldefaults[type].Invoke(control);
            }
        }
        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                 FindAndInvoke(control.GetType(), control);
            }
        }
        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class 
        {
            if (!controldefaults.ContainsKey(typeof(T))) return;
    
            foreach (Control control in controls)
            {
               if (control.GetType().Equals(typeof(T)))
               {
                   FindAndInvoke(typeof(T), control);
               }
            }    
        
        }
    }
