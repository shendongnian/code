    public class Vector3D<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
        private readonly String filePath;
        public Vector3D(String filePath) {
            this.filePath = filePath;
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    using(BinaryReader br = new BinaryReader(fs))
                    {
                        X = (T) GetValue<T>(br);
                        Y = (T) GetValue<T>(br);
                        Z = (T) GetValue<T>(br);
                    }
                }
            }
        }
        public static Object GetValue<T>(BinaryReader br) {
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
