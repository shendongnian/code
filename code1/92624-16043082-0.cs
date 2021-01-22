    public static object[,] ToObjectArray(this Object Range)
        {
            Type type = Range.GetType();
            if (type.IsArray && type.Name == "Object[,]")
            {
                var sourceArray = Range as Object[,];               
                int lb1 = sourceArray.GetLowerBound(0);
                int lb2 = sourceArray.GetLowerBound(1);
                if (lb1 == 0 && lb2 == 0)
                {
                    return sourceArray;
                }
                else
                {
                    int numRows = sourceArray.GetLength(0);
                    int numColumns = sourceArray.GetLength(1);
                    var resultArray = new Object[numRows, numColumns];
                    for (int r = 0; r < numRows; r++)
                    {
                        for (int c = 0; c < numColumns; c++)
                        {
                            resultArray[r, c] = sourceArray[lb1 + r, lb2 + c];
                        }
                    }
                    return resultArray;
                }
            }
            else if (type.IsCOMObject) 
            {
                // Get the Value2 property from the object.
                Object value = type.InvokeMember("Value2",
                       System.Reflection.BindingFlags.Instance |
                       System.Reflection.BindingFlags.Public |
                       System.Reflection.BindingFlags.GetProperty,
                       null,
                       Range,
                       null);
                if (value == null)
                    value = string.Empty;
                if (value is string)
                    return new object[,] { { value } };
                else if (value is double)
                    return new object[,] { { value } };
                else
                {
                    object[,] range = (object[,])value;
                    int rows = range.GetLength(0);
                    int columns = range.GetLength(1);
                    object[,] param = new object[rows, columns];
                    Array.Copy(range, param, rows * columns);
                    return param;
                }
            }
            else
                throw new ArgumentException("Not A Excel Range Com Object");
        }
