    public static void CloneControl(Control SourceControl, Control DestinationControl)
    {
        String[] PropertiesToClone = new String[] { "Size", "Font", "Text", "Tag", "BackColor", "BorderStyle", "TextAlign", "Width", "Margin" };
        PropertyInfo[] controlProperties = SourceControl.GetType().GetProperties();
        foreach (String Property in PropertiesToClone)
        {
            PropertyInfo ObjPropertyInfo = controlProperties.First(a => a.Name == Property);
            ObjPropertyInfo.SetValue(DestinationControl, ObjPropertyInfo.GetValue(SourceControl));
        }
    }
