    public static class BinaryReaderExtensions
    {
        public static Object GetValue<T>(this BinaryReader br)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean: { return br.ReadBoolean(); }
                case TypeCode.Byte: { return br.ReadByte(); }
                case TypeCode.Char: { return br.ReadChar(); }
                case TypeCode.Decimal: { return br.ReadDecimal(); }
                case TypeCode.Double: { return br.ReadDouble(); }
                case TypeCode.Int16: { return br.ReadInt16(); }
                case TypeCode.Int32: { return br.ReadInt32(); }
                case TypeCode.Int64: { return br.ReadUInt64(); }
                default: { return br.Read(); }
            }
        }
    }
}
