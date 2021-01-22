    // Let's say controls is a ControlCollection
    var enumerable = controls.Cast<Control>();
    
    // Not sure what you mean by "top", actually --
    // wouldn't the control with the lowest X be leftmost?
    int minimumX = enumerable.Min(c => c.Location.X);
    Control topControl = enumerable.Where(c => c.Location.X == minimumX);
    
    controls.Remove(topControl);
