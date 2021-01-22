	public class Box<T>: IConvertible where T: struct, IConvertible {
		public static implicit operator T(Box<T> boxed) {
			return boxed.Value;
		}
		public static explicit operator Box<T>(T value) {
			return new Box<T>(value);
		}
		private readonly T value;
		public Box(T value) {
			this.value = value;
		}
		public T Value {
			get {
				return value;
			}
		}
		public override bool Equals(object obj) {
			Box<T> boxed = obj as Box<T>;
			if (boxed != null) {
				return value.Equals(boxed.Value);
			}
			return value.Equals(obj);
		}
		public override int GetHashCode() {
			return value.GetHashCode();
		}
		public override string ToString() {
			return value.ToString();
		}
		bool IConvertible.ToBoolean(IFormatProvider provider) {
			return value.ToBoolean(provider);
		}
		char IConvertible.ToChar(IFormatProvider provider) {
			return value.ToChar(provider);
		}
		sbyte IConvertible.ToSByte(IFormatProvider provider) {
			return value.ToSByte(provider);
		}
		byte IConvertible.ToByte(IFormatProvider provider) {
			return value.ToByte(provider);
		}
		short IConvertible.ToInt16(IFormatProvider provider) {
			return value.ToInt16(provider);
		}
		ushort IConvertible.ToUInt16(IFormatProvider provider) {
			return value.ToUInt16(provider);
		}
		int IConvertible.ToInt32(IFormatProvider provider) {
			return value.ToInt32(provider);
		}
		uint IConvertible.ToUInt32(IFormatProvider provider) {
			return value.ToUInt32(provider);
		}
		long IConvertible.ToInt64(IFormatProvider provider) {
			return value.ToInt64(provider);
		}
		ulong IConvertible.ToUInt64(IFormatProvider provider) {
			return value.ToUInt64(provider);
		}
		float IConvertible.ToSingle(IFormatProvider provider) {
			return value.ToSingle(provider);
		}
		double IConvertible.ToDouble(IFormatProvider provider) {
			return value.ToDouble(provider);
		}
		decimal IConvertible.ToDecimal(IFormatProvider provider) {
			return value.ToDecimal(provider);
		}
		DateTime IConvertible.ToDateTime(IFormatProvider provider) {
			return value.ToDateTime(provider);
		}
		string IConvertible.ToString(IFormatProvider provider) {
			return value.ToString(provider);
		}
		object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
			return value.ToType(conversionType, provider);
		}
	}
