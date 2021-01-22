        static object Parse(Type type, string s)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return bool.Parse(s);
                case TypeCode.Byte: return byte.Parse(s);
                case TypeCode.Char: return s[0];
                case TypeCode.DateTime: return DateTime.Parse(s);
                    ...
            }
        }
