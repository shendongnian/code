    [Serializable]
    [ComVisible(true)]
    public struct BOOL : IComparable, IConvertible, IComparable<BOOL>, IEquatable<BOOL>, IComparable<bool>, IEquatable<bool>
    {
        private uint _data;
        public BOOL(bool value) { _data = value ? 1u : 0u; }
        public BOOL(int value) { _data = unchecked((uint)value); }
        public BOOL(uint value) { _data = value; }
        private bool Value { get { return _data != 0; } }
        private IConvertible Convertible { get { return _data != 0; } }
        #region IComparable Members
        public int CompareTo(object obj) { return Value.CompareTo(obj); }
        #endregion
        #region IConvertible Members
        public TypeCode GetTypeCode() { return Value.GetTypeCode(); }
        public string ToString(IFormatProvider provider) { return Value.ToString(provider); }
        bool IConvertible.ToBoolean(IFormatProvider provider) { return Convertible.ToBoolean(provider); }
        byte IConvertible.ToByte(IFormatProvider provider) { return Convertible.ToByte(provider); }
        char IConvertible.ToChar(IFormatProvider provider) { return Convertible.ToChar(provider); }
        DateTime IConvertible.ToDateTime(IFormatProvider provider) { return Convertible.ToDateTime(provider); }
        decimal IConvertible.ToDecimal(IFormatProvider provider) { return Convertible.ToDecimal(provider); }
        double IConvertible.ToDouble(IFormatProvider provider) { return Convertible.ToDouble(provider); }
        short IConvertible.ToInt16(IFormatProvider provider) { return Convertible.ToInt16(provider); }
        int IConvertible.ToInt32(IFormatProvider provider) { return Convertible.ToInt32(provider); }
        long IConvertible.ToInt64(IFormatProvider provider) { return Convertible.ToInt64(provider); }
        sbyte IConvertible.ToSByte(IFormatProvider provider) { return Convertible.ToSByte(provider); }
        float IConvertible.ToSingle(IFormatProvider provider) { return Convertible.ToSingle(provider); }
        ushort IConvertible.ToUInt16(IFormatProvider provider) { return Convertible.ToUInt16(provider); }
        uint IConvertible.ToUInt32(IFormatProvider provider) { return Convertible.ToUInt32(provider); }
        ulong IConvertible.ToUInt64(IFormatProvider provider) { return Convertible.ToUInt64(provider); }
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) { return Convertible.ToType(conversionType, provider); }
        #endregion
        #region IComparable<bool> Members
        public int CompareTo(BOOL other) { return Value.CompareTo(other.Value); }
        public int CompareTo(bool other) { return Value.CompareTo(other); }
        #endregion
        #region IEquatable<bool> Members
        public bool Equals(BOOL other) { return Value.Equals(other.Value); }
        public bool Equals(bool other) { return Value.Equals(other); }
        #endregion
        #region Object Override
        public override string ToString() { return Value.ToString(); }
        public override int GetHashCode() { return Value.GetHashCode(); }
        public override bool Equals(object obj) { return Value.Equals(obj); }
        #endregion
        #region implicit/explicit cast operators
        public static implicit operator bool(BOOL value) { return value.Value; }
        public static implicit operator BOOL(bool value) { return new BOOL(value); }
        public static explicit operator int(BOOL value) { return unchecked((int)value._data); }
        public static explicit operator BOOL(int value) { return new BOOL(value); }
        public static explicit operator uint(BOOL value) { return value._data; }
        public static explicit operator BOOL(uint value) { return new BOOL(value); }
        #endregion
        #region +, -, !, ~, ++, --, true, false unary operators overloaded.
        public static BOOL operator !(BOOL b) { return new BOOL(!b.Value); }
        public static bool operator true(BOOL b) { return b.Value; }
        public static bool operator false(BOOL b) { return !b.Value; }
        #endregion
        #region +, -, *, /, %, &, |, ^, <<, >> binary operators overloaded.
        public static BOOL operator &(BOOL b1, BOOL b2) { return new BOOL(b1.Value & b2.Value); }
        public static BOOL operator |(BOOL b1, BOOL b2) { return new BOOL(b1.Value | b2.Value); }
        #endregion
        #region ==, !=, <, >, <=, >= comparison operators overloaded
        public static bool operator ==(BOOL b1, BOOL b2) { return (b1.Value == b2.Value); }
        public static bool operator !=(BOOL b1, BOOL b2) { return (b1.Value != b2.Value); }
        #endregion
    }
