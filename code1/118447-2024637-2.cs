    public static Control FindControl(this Control root, string name) {
        if(root == null) throw new ArgumentNullException("root");
        foreach(Control child in root.Controls) {
            if(child.Name == name) return child;
            Control found = FindControl(child, name);
            if(found != null) return found;
        }
        return null;
    }
