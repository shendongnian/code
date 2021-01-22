    public static class Serializer
    {
        public static byte[] GetBytes<T>(T structure, bool respectEndianness = true) where T : struct
        {
            var size = Marshal.SizeOf(structure); //or Marshal.SizeOf<T>(); in .net 4.5.1
            var bytes = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);
            if (respectEndianness) RespectEndianness(typeof(T), bytes);  
            return bytes;
        }
        public static T FromBytes<T>(byte[] bytes, bool respectEndianness = true) where T : struct
        {
            var structure = new T();
            if (respectEndianness) RespectEndianness(typeof(T), bytes);    
            int size = Marshal.SizeOf(structure);  //or Marshal.SizeOf<T>(); in .net 4.5.1
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            structure = (T)Marshal.PtrToStructure(ptr, structure.GetType());
            Marshal.FreeHGlobal(ptr);
            return structure;
        }
        private static void RespectEndianness(Type type, byte[] data, int offSet = 0)
        {
            var fields = type.GetFields()
                .Select(f => new
                {
                    Field = f,
                    Offset = Marshal.OffsetOf(type, f.Name).ToInt32(),
                }).ToList();
            foreach (var field in fields)
            {
                if (field.Field.FieldType.IsArray)
                {
                    //handle arrays, assuming fixed length
                    var attr = field.Field.GetCustomAttributes(typeof(MarshalAsAttribute), false).FirstOrDefault();
                    var marshalAsAttribute = attr as MarshalAsAttribute;
                    if (marshalAsAttribute == null || marshalAsAttribute.SizeConst == 0)
                        throw new NotSupportedException(
                            "Array fields must be decorated with a MarshalAsAttribute with SizeConst specified.");
                    var arrayLength = marshalAsAttribute.SizeConst;
                    var elementType = field.Field.FieldType.GetElementType();
                    var elementSize = Marshal.SizeOf(elementType);
                    for (int i = field.Offset + offSet; i < elementSize * arrayLength; i += elementSize)
                    {
                        RespectEndianness(elementType, data, i);
                    }
                }
                else if (!field.Field.FieldType.IsPrimitive) //or !field.Field.FiledType.GetFields().Length == 0
                {
                    //handle nested structs
                    RespectEndianness(field.Field.FieldType, data, field.Offset);
                }
                else
                {
                    //handle primitive types
                    Array.Reverse(data, offSet + field.Offset, Marshal.SizeOf(field.Field.FieldType));
                }
            }
        }
    }
