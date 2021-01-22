            // ************************************************************************
    		public static void SetObjectPropertyDescription(this Type typeOfObject, string propertyName,  string description)
    		{
    			PropertyDescriptor pd = TypeDescriptor.GetProperties(typeOfObject)[propertyName];
    			var att = pd.Attributes[typeof(DescriptionAttribute)] as DescriptionAttribute;
    			if (att != null)
    			{
    				var fieldDescription = att.GetType().GetField("description", BindingFlags.NonPublic | BindingFlags.Instance);
    				if (fieldDescription != null)
    				{
    					fieldDescription.SetValue(att, description);
    				}
    			}
    		}
    
    		// ************************************************************************
    		public static void SetPropertyAttributReadOnly(this Type typeOfObject, string propertyName, bool isReadOnly)
    		{
    			PropertyDescriptor pd = TypeDescriptor.GetProperties(typeOfObject)[propertyName];
    			var att = pd.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute;
    			if (att != null)
    			{
    				var fieldDescription = att.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
    				if (fieldDescription != null)
    				{
    					fieldDescription.SetValue(att, isReadOnly);
    				}
    			}
    		}
