    public static DTE2 GetDTE(object dataContext)
    {
    	ICustomTypeDescriptor typeDescriptor = dataContext as ICustomTypeDescriptor;
    	Debug.Assert(typeDescriptor != null, "Could not get ICustomTypeDescriptor from dataContext. Was the Start Page tool window DataContext overwritten?");
    	PropertyDescriptorCollection propertyCollection = typeDescriptor.GetProperties();
    	return propertyCollection.Find("DTE", false).GetValue(dataContext) as DTE2;
    }
