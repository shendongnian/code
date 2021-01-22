    protected void SetPropertyValueCore(object obj, object value, bool doUndo)
    {
        if (this.propertyInfo != null)
        {
            Cursor current = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                object component = obj;
                if (component is ICustomTypeDescriptor)
                {
                    component = ((ICustomTypeDescriptor) component).GetPropertyOwner(this.propertyInfo);
                }
                bool flag = false;
                if (this.ParentGridEntry != null)
                {
                    Type propertyType = this.ParentGridEntry.PropertyType;
                    flag = propertyType.IsValueType || propertyType.IsArray;
                }
                if (component != null)
                {
                    this.propertyInfo.SetValue(component, value);
                    if (flag)
                    {
                        GridEntry parentGridEntry = this.ParentGridEntry;
                        if ((parentGridEntry != null) && parentGridEntry.IsValueEditable)
                        {
                            parentGridEntry.PropertyValue = obj;
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = current;
            }
        }
    }
