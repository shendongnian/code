    protected void Page_Load(object sender, EventArgs e)
    {
        foreach(var control in GetControls(Controls))
        {
            var textBox = control as TextBox;
            if ( textBox != null )
            {
                //textBox.Text;
                continue;
            }
    
            var dropdown = control as DropDownList;
            if ( dropdown != null )
            {
                //dropdown.SelectedValue;
                continue;
            }
    
            // etc...
        }
    }
    
    private static IEnumerable<Control> GetControls(ControlCollection controlCollection)
    {
        foreach (Control control in controlCollection)
        {
            yield return control;
    
            if ( control.Controls == null || control.Controls.Count == 0 )
                continue;
    
            foreach (var sub in GetControls(control.Controls))
            {
                yield return sub;
            }
        }
    }
