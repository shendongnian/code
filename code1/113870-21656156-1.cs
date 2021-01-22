    public InheritingClass : BaseClass
    {
       private static FieldInfo _valueField = typeof(BaseClass).GetField("_values", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    
       public InheritingClass()
       {
            _valueField.SetValue(this, new InhertingList<string>());
       }
    }
