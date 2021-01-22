    private Control CloneControl(Control srcCtl)
    {
        var cloned = Activator.CreateInstance(srcCtl.GetType()) as Control;
        var binding = BindingFlags.Public | BindingFlags.Instance;
        foreach(PropertyInfo prop in srcCtl.GetType().GetProperties(binding))
        {
            if (IsClonable(prop))
            {
                object val = prop.GetValue(srcCtl);
                prop.SetValue(cloned, val, null);
            }
        }
        foreach(Control ctl in srcCtl.Controls)
        {
            cloned.Controls.Add(CloneControl(ctl));
        }
        return cloned;
    }
    private bool IsClonable(PropertyInfo prop)
    {
        var browsableAttr = prop.GetCustomAttribute(typeof(BrowsableAttribute), true) as BrowsableAttribute;
        var editorBrowsableAttr = prop.GetCustomAttribute(typeof(EditorBrowsableAttribute), true) as EditorBrowsableAttribute;
        return prop.CanWrite
            && (browsableAttr == null || browsableAttr.Browsable == true)
            && (editorBrowsableAttr == null || editorBrowsableAttr.State != EditorBrowsableState.Advanced);
    }
