    public void AcceptChanges()
    {
        foreach (FieldInfo field in GetType().GetFields()) {
            if (!typeof(IColumn).IsAssignableFrom(field.FieldType))
                continue; // ignore all non-IColumn fields
            IColumn col = (IColumn)field.GetValue(this); // Boxes storage -> clone
            col.AcceptChanges(); // Works on clone
            field.SetValue(this, col); // Unboxes clone -> storage
        }
    }
