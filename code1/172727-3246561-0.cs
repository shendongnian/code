    public IEnumerable<Control> GetChildrenRecursive(Control parent)
    {
        var controls = new List<Control>();
        foreach(Control child in parent.Controls)
            controls.AddRange(GetChildrenRecursive(child));
        return controls;
    }
    
    TextBox[] textboxes = GetChildrenRecursive(this)
           .OfType<TextBox>().OrderBy(i => i.Name).ToArray();
