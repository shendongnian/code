    private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() { 
                {typeof(TextBox), c => ((TextBox)c).Clear()},
                {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
                {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
                {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
                {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
                {typeof(Panel), c => ((Panel)c).Controls.ClearControls()}
        };
