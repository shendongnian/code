    Type type = typeof(ExampleDropDownViewModel));
    // Get properties of your data class
    PropertyInfo[] propertyInfo = type.GetProperties( );
    foreach( PropertyInfo prop in propertyInfo )
    {
       // Fetch custom attributes applied to a property        
       object[] attributes = prop.GetCustomAttributes(true);
       foreach (Attribute attribute in attributes) {
          // we are only interested in DropDownList Attributes..
          if (attribute is DropDownListAttribute) {
	    DropDownListAttribute dropdownAttrib = (DropDownListAttribute)attribute;
             Console.WriteLine("table set in attribute: " + dropdownAttrib.myTable);
          }
       }
    }
