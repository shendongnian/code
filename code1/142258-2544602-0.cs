    private void ConvertToTypeAndUseCustomProperty(Control c) 
    { 
       PropertyInfo p = c.GetType().GetProperty("CustomPropertieOfControl"); 
       if (p == null)
         return;
       p.SetValue(c, new object[] { 234567 }); 
    }
