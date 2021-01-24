    public static class DataRowExtension 
    {
        // Class for: Conversion to object[]
        public static object[] ToObjectArray(this DataRow dataRow)
        {
            // Identifiers used are:
            int columnCount = dataRow.Table.Columns.Count;
            object[] objectArray = new object[columnCount];
            // Check the row is not empty
            if (columnCount == 0)
            {
                return null;
            }
            // Go through the row to add each element to the array
            for (int i = 0; i < columnCount; i++)
            {
                objectArray[i] = dataRow[i];
            }
            // Return the object array
            return objectArray;
        }
    }
