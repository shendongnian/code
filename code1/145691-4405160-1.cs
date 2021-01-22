    private static void RespectEndianness(Type type, byte[] data) {
        foreach (FieldInfo f in type.GetFields()) {
            if (f.IsDefined(typeof(EndianAttribute), false)) {
                EndianAttribute att = (EndianAttribute)f.GetCustomAttributes(typeof(EndianAttribute), false)[0];
                int offset = Marshal.OffsetOf(type, f.Name).ToInt32();
                if ((att.Endianness == Endianness.BigEndian && BitConverter.IsLittleEndian) ||
                    (att.Endianness == Endianness.LittleEndian && !BitConverter.IsLittleEndian)) {
                    Array.Reverse(data, offset, Marshal.SizeOf(f.FieldType));
                }
            }
        }
    }
