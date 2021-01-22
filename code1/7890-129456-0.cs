    protected void Page_Load(object sender, EventArgs e)
    {
    
        foreach (Control control in GetControlsByType(this, typeof(TextBox)))
        { 
            //Do something?
        }
    
    }
    public static System.Collections.Generic.List<Control> GetControlsByType(Control ctrl, Type t)
    {
        System.Collections.Generic.List<Control> cntrls = new System.Collections.Generic.List<Control>();
    
       
        foreach (Control child in ctrl.Controls)
        {
            if (t == child.GetType())
                cntrls.Add(child);
            cntrls.AddRange(GetControlsByType(child, t));
        }
        return cntrls;
    }
