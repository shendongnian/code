    SetUsingReflection("tName", 0, "TheNewValue");
    // ...
    // if the type isn't known until run-time...
    private void SetUsingReflection(string fieldName, int index, object newValue)
    {
        FieldInfo fieldInfo = this.GetType().GetField(fieldName);
        object fieldValue = fieldInfo.GetValue(this);
        ((Array)fieldValue).SetValue(newValue, index);
    }
    // if the type is already known at compile-time...
    private void SetUsingReflection<T>(string fieldName, int index, T newValue)
    {
        FieldInfo fieldInfo = this.GetType().GetField(fieldName);
        object fieldValue = fieldInfo.GetValue(this);
        ((T[])fieldValue)[index] = newValue;
    }
