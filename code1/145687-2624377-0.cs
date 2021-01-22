    [AttributeUsage(AttributeTargets.Field)]
    public class EndienAttribute : Attribute
    {
        public Endienness Endienness { get; private set; }
        public EndienAttribute(Endienness endienness)
        {
            this.Endienness = endienness;
        }
    }
    public enum Endienness
    {
        BigEndien,
        LittleEndien
    }
    private static void RespectEndienness(Type type, byte[] data)
    {
        var fields = type.GetFields().Where(f => f.IsDefined(typeof(EndienAttribute), false))
            .Select(f => new
            {
                Field = f,
                Attribute = (EndienAttribute)f.GetCustomAttributes(typeof(EndienAttribute), false)[0],
                Offset = Marshal.OffsetOf(type, f.Name).ToInt32()
            }).ToList();
        foreach (var field in fields)
        {
            if ((field.Attribute.Endienness == Endienness.BigEndien && BitConverter.IsLittleEndian) ||
                (field.Attribute.Endienness == Endienness.LittleEndien && !BitConverter.IsLittleEndian))
            {
                Array.Reverse(data, field.Offset, Marshal.SizeOf(field.Field.FieldType));
            }
        }
    }
    private static T BytesToStruct<T>(byte[] rawData) where T : struct
    {
        T result = default(T);
        RespectEndienness(typeof(T), rawData);     
        GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
        try
        {
            IntPtr rawDataPtr = handle.AddrOfPinnedObject();
            result = (T)Marshal.PtrToStructure(rawDataPtr, typeof(T));
        }
        finally
        {
            handle.Free();
        }        
        return result;
    }
    private static byte[] StructToBytes<T>(T data) where T : struct
    {
        byte[] rawData = new byte[Marshal.SizeOf(data)];
        GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
        try
        {
            IntPtr rawDataPtr = handle.AddrOfPinnedObject();
            Marshal.StructureToPtr(data, rawDataPtr, false);
        }
        finally
        {
            handle.Free();
        }
        RespectEndienness(typeof(T), rawData);     
        return rawData;
    }
