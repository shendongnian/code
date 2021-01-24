    public Child Copy()
    {
        Child copy = new Child()
        {
            Data = this.Data
        };
        FieldInfo eventBackingField = typeof(Parent).GetField(nameof(Event), BindingFlags.Instance | BindingFlags.NonPublic);
        if (eventBackingField == null)
            return; // oops, not an auto event, it has explicit accessors
        
        // copy.Event = this.Event:
        eventBackingField.SetValue(copy, eventBackingField.GetValue(this));
        return copy;
    }
