    PropertyInfo marginProperty = stp.GetType().GetProperty("Margin", BindingFlags.Public | BindingFlags.Instance);
    if (null != marginProperty)
    {
        Thickness thickness = (Thickness)marginProperty.GetValue(stp);
        marginProperty.SetValue(stp, new Thickness(100d, thickness.Top, thickness.Right, thickness.Bottom));
    }
