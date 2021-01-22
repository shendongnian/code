    To use it with DataGridView create a ToolTip (HtmlToolTip) and add this after the InitalizeComponent() in your form to replace the default tooltip:
    
    System.Reflection.FieldInfo toolTipControlFieldInfo=
    typeof(DataGridView).GetField("toolTipControl", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    
    System.Reflection.FieldInfo toolTipFieldInfo=
    toolTipControlFieldInfo.FieldType.GetField("toolTip", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    
    object toolTipControlInstance =
    toolTipControlFieldInfo.GetValue(myDataGridView);
    
    toolTipFieldInfo.SetValue(toolTipControlInstance, myToolTip);
