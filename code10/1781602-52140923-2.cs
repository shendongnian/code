    // extension function: gets the size of a control
    public static int GetSize(this Control control)
    {
        return control.Height * control.Width);
    }
    // returns the smallest control, by size, or null if there isn't any control
    public static Control SmallestControlOrDefault(this IEnumerable<Control> controls)
    {
        if (controls == null || !controls.Any()) return null; // default
        Control smallestControl = controls.First();
        int smallestSize = smallesControl.GetSize();
        
        // check all other controls if they are smaller
        foreach (var control in controls.Skip(1))
        {
            int size = control.GetSize();
            if (size < smallestSize)
            {
                 smallestControl = control;
                 smallestSize = size;
            }
        }
        return smallestControl;
    }
