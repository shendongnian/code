    public static IEnumerable<Control> 
                               GetDeepControlsByType<T>(this Control control)
    {
       return control.Controls.OfType<T>()
              .Union(control.Controls.SelectMany(c => c.GetDeepControlsByType<T>()));        
    }
 
