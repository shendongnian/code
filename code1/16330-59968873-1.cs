    using System;
    
    namespace McKabue.Extentions.Utility.Enums
    {
        /// <summary>
        /// <see href="https://stackoverflow.com/q/261663/3563013">
        /// Can we define implicit conversions of enums in c#?
        /// </see>
        /// </summary>
        public struct PrimitiveEnum
        {
            private Enum _enum;
    
            public PrimitiveEnum(Enum _enum)
            {
                this._enum = _enum;
            }
    
            public Enum ServiceErrorCode => _enum;
    
    
            public static implicit operator PrimitiveEnum(Enum _enum)
            {
                return new PrimitiveEnum(_enum);
            }
    
            public static implicit operator Enum(PrimitiveEnum primitiveEnum)
            {
                return primitiveEnum.ServiceErrorCode;
            }
    
            public static implicit operator byte(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToByte(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator sbyte(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToSByte(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator short(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToInt16(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator ushort(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToUInt16(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator int(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToInt32(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator uint(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToUInt32(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator long(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToInt64(primitiveEnum.ServiceErrorCode);
            }
    
            public static implicit operator ulong(PrimitiveEnum primitiveEnum)
            {
                return Convert.ToUInt64(primitiveEnum.ServiceErrorCode);
            }
        }
    }
