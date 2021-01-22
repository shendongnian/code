    /// <summary>
    /// Returns whether the function is being executed during design time in Visual Studio.
    /// </summary>
    public static bool IsDesignTime(this Control control)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            return true;
        }
        if (control.Site != null && control.Site.DesignMode)
        {
            return true;
        }
        var parent = control.Parent;
        while (parent != null)
        {
            if (parent.Site != null && parent.Site.DesignMode)
            {
                return true;
            }
            parent = parent.Parent;
        }
        return false;
    }
    /// <summary>
    /// Sets the DropDownWidth to ensure that no item's text is cut off.
    /// </summary>
    public static void SetDropDownWidth(this ComboBox comboBox)
    {
        var g = comboBox.CreateGraphics();
        var font = comboBox.Font;
        float maxWidth = 0;
        foreach (var item in comboBox.Items)
        {
            maxWidth = Math.Max(maxWidth, g.MeasureString(item.ToString(), font).Width);
        }
        if (comboBox.Items.Count > comboBox.MaxDropDownItems)
        {
            maxWidth += SystemInformation.VerticalScrollBarWidth;
        }
        comboBox.DropDownWidth = Math.Max(comboBox.Width, Convert.ToInt32(maxWidth));
    }
