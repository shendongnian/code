    // Let's say controls is a ControlCollection
    var enumerable = controls.Cast<Control>();
    int minimumY = enumerable.Min(c => c.Location.Y);
    Control topControl = enumerable.Where(c => c.Location.Y == minimumY);
    
    controls.Remove(topControl);
