    // Return a list with all the private fields with the same type
    List<T> GetAllControlsWithTypeFromControl<T>(Control parentControl)
    {
        List<T> retValue = new List<T>();
        System.Reflection.FieldInfo[] fields = parentControl.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (System.Reflection.FieldInfo field in fields)
        {
          if (field.FieldType == typeof(T))
            retValue.Add((T)field.GetValue(parentControl));
        }
    }
    
    List<TextBox> ctrls = GetAllControlsWithTypeFromControl<TextBox>(this);
          
