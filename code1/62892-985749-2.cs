    bool isFirstRow = true;
    Type rowType = typeof( System.Data.Objects.DataClasses.EntityObject );
    Type propType;
    System.Reflection.PropertyInfo propInfo;
    object propObject;
    string[] propNames;
    foreach ( var row in Model.Data )
    {
        if ( isFirstRow )
        {
            // Get the type of entity we're enumerating through
            rowType = row.GetType();
            isFirstRow = false;
        }
        
        // Enumerate through the columns
        foreach ( var kvp in Model.Headings )
        {
            propNames = kvp.Key.Split( '.' );
            propObject = row;
            propType = rowType;
            // Drill down through the entity properties so we can
            // handle properties like "Ticket.Company.Name"
            foreach ( var propName in propNames )
            {
                try
                {
                    propInfo = propType.GetProperty( propName );
                    propObject = propInfo.GetValue( propObject, null );
                    propType = propObject.GetType();
                }
                catch ( NullReferenceException ) { }
            }
            try
            {
                Response.Write( "<td>" + Html.Encode( propObject.ToString() ) + "</td>" );
            }
            catch ( NullReferenceException )
            {
                Response.Write( "<td>--</td>" );
            }
        }
    }
