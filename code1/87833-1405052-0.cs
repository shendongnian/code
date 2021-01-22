        public static DataTable ToDataTable<T>(this IList<T> theList)
        {
            DataTable theTable = CreateTable<T>();
            Type theEntityType = typeof(T);
            // Use reflection to get the properties of the generic type (T)
            PropertyDescriptorCollection theProperties = TypeDescriptor.GetProperties(theEntityType);
            // Loop through each generic item in the list
            foreach (T theItem in theList)
            {
                DataRow theRow = theTable.NewRow();
                // Loop through all the properties
                foreach (PropertyDescriptor theProperty in theProperties)
                {
                    // Retrieve the value and check to see if it is null
                    object thePropertyValue = theProperty.GetValue(theItem);
                    if (null == thePropertyValue)
                    {
                        // The value is null, so we need special treatment, because a DataTable does not like null, but is okay with DBNull.Value
                        theRow[theProperty.Name] = DBNull.Value;
                    }
                    else
                    {
                        // No problem, just slap the value in
                        theRow[theProperty.Name] = theProperty.GetValue(theItem);
                    }
                }
                theTable.Rows.Add(theRow);
            }
            return theTable;
        }
