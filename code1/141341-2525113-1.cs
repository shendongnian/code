    public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
    {
        List<Control> controls = new List<Control>();
    
        foreach(Control child in parent.Controls)
        {
            controls.AddRange(GetSelfAndChildrenRecursive(child));
        }
    
        controls.Add(parent);
    
        return controls;
    }
    
    var result = GetSelfAndChildrenRecursive(topLevelControl)
        .Where(c => c is TextBox || c is Checkbox);
