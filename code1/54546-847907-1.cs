    [Serializable]
    public class EncryptedStringType : PrimitiveType
    {
        public EncryptedStringType() : this(new BinarySqlType()) {}
    
        public EncryptedStringType(SqlType sqlType) : base(sqlType) {}
    
        public override string Name
        {
            get { return "String"; }
        }
    
        public override Type ReturnedClass
        {
            get { return typeof (string); }
        }
    
        public override Type PrimitiveClass
        {
            get { return typeof (string); }
        }
    
        public override object DefaultValue
        {
            get { return null; }
        }
    
        public override void Set(IDbCommand cmd, object value, int index)
        {
            if (cmd == null) throw new ArgumentNullException("cmd");
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = null;
            }
            else
            {
                ((IDataParameter)cmd.Parameters[index]).Value = EncryptionManager.Provider.Encrypt((string)value);
            }
        }
    
        public override object Get(IDataReader rs, int index)
        {
            if (rs == null) throw new ArgumentNullException("rs");
            var encrypted = rs[index] as byte[];
            if (encrypted == null) return null;
            return EncryptionManager.Provider.Decrypt(encrypted);
        }
    
        public override object Get(IDataReader rs, string name)
        {
            return Get(rs, rs.GetOrdinal(name));
        }
    
        public override object FromStringValue(string xml)
        {
            if (xml == null)
            {
                return null;
            }
    
            if (xml.Length % 2 != 0)
            {
                throw new ArgumentException(
                    "The string is not a valid xml representation of a binary content.",
                    "xml");
            }
    
            var bytes = new byte[xml.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string hexStr = xml.Substring(i * 2, (i + 1) * 2);
                bytes[i] = (byte)(byte.MinValue
                                  + byte.Parse(hexStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
            }
    
            return EncryptionManager.Provider.Decrypt(bytes);
        }
    
        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            var bytes = value as byte[];
            if (bytes == null)
            {
                return "NULL";
            }
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                string hexStr = (bytes[i] - byte.MinValue).ToString("x", CultureInfo.InvariantCulture);
                if (hexStr.Length == 1)
                {
                    builder.Append('0');
                }
                builder.Append(hexStr);
            }
            return builder.ToString();
        }
    }
