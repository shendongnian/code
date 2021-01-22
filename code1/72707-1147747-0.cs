    public string GetValue(string id, ref FormView fv)
    {
        Control ctrl = fv.FindControl(id);
        string value = "";
    
        if(ctrl is TextBox)
        {
           TextBox tb = (TextBox)ctrl);
           value = tb.Text;
        }
        else if(ctrl is DropDownList)
        {
            DropDownList ddl = (DropDownList)ctrl;
            value = ddl.SelectedValue;
        }
        else if( ...
        ...
        ...
    
        return(value);
    }
    
    public void SetValue(string id, string value, ref FormView fv)
    {
        Control ctrl = fv.FindControl(id);
    
        if(ctrl is TextBox)
        {
           TextBox tb = (TextBox)ctrl);
           tb.Text = value;
        }
        else if(ctrl is DropDownList)
        {
            DropDownList ddl = (DropDownList)ctrl;
            ddl.SelectedValue = value;
        }
        else if( ...
        ...
        ...
    }
