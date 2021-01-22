    Type tp = tlpMyPanel.GetType().BaseType;
    System.Reflection.PropertyInfo pi = 
        tp.GetProperty("DoubleBuffered",
        System.Reflection.BindingFlags.Instance 
        | System.Reflection.BindingFlags.NonPublic);
    pi.SetValue(tlpMyPanel, true, null);
