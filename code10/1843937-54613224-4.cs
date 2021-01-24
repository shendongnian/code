    var f = typeof(Control).GetField("EventValidating",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static);
    var validating = (CancelEventHandler)Events[f.GetValue(this)];
    validating?.Invoke(this, e);  //You can set another sender instead of this
