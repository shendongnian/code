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
        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (controldefaults.ContainsKey(control.GetType())){
                    controldefaults[control.GetType()].Invoke(control);
                };
            }
        }
    }
