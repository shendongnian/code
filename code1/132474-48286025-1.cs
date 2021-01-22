        /// <summary>
        /// Gets the size of object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="avgStringSize">Average size of the string.</param>
        /// <returns>An approximation of the size of the object in bytes</returns>
        public static int GetSizeOfObject(object obj, int avgStringSize=-1)
        {
            int pointerSize = IntPtr.Size;
            int size = 0;
            Type type = obj.GetType();
            var info = type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            foreach (var field in info)
            {
                if (field.FieldType.IsValueType)
                {
                    size += System.Runtime.InteropServices.Marshal.SizeOf(field.FieldType);
                }
                else
                {
                    size += pointerSize;
                    if (field.FieldType.IsArray)
                    {
                        var array = field.GetValue(obj) as Array;
                        if (array != null)
                        {
                            var elementType = array.GetType().GetElementType();
                            if (elementType.IsValueType)
                            {
                                size += System.Runtime.InteropServices.Marshal.SizeOf(field.FieldType) * array.Length;
                            }
                            else
                            {
                                size += pointerSize * array.Length;
                                if (elementType == typeof(string) && avgStringSize > 0)
                                {
                                    size += avgStringSize * array.Length;
                                }
                            }
                        }
                    }
                    else if (field.FieldType == typeof(string) && avgStringSize > 0)
                    {
                        size += avgStringSize;
                    }
                }
            }
            return size;
        }
