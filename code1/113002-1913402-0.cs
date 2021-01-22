    public static class DataExtensions
    {
        public static DataRow AddRow(this DataRowCollection rowCollection, params object[] values)
        {
            object[] newValues = new object[values.Length];
            for(int i=0;i<values.Length;i++)
            {
                object value = values[i];
                if (value != null)
                {                    
                    Type t = value.GetType();
                    //check for min value only for value types...
                    if (t.IsValueType)
                    {
                        //maybe you can do some caching for that...
                        FieldInfo info = t.GetField("MinValue",
                            System.Reflection.BindingFlags.Static
                            | System.Reflection.BindingFlags.Public
                            );
                        if (info != null)
                        {
                            object o = info.GetValue(null);
                            if (value.Equals(o))  //very important == will return false
                            {
                                value = DBNull.Value;
                            }
                        }
                    }
                }
                newValues[i] = value;               
            }
            return rowCollection.Add(newValues);
        }
    }
