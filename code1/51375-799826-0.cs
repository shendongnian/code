    public void ChangeProperties(Form form, string category)
    {
       string[] parts = category.Split(".");
       int index = form.Controls.IndexOfKey(parts[0]);
       
       Control control = null;
       if (index >= 0)
       {
         control = form.Controls[index].;
       }
       if (control != null)
       {
         PropertyInfo propertyInfo = control.GetType().GetProperty(parts[1]);
         if (propertyInfo != null)
         {
           propertyInfo.SetValue(control, true);
         }
       }
    }
