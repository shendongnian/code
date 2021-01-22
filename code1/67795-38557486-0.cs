	#define NUMERICS
	using System;
	using System.Collections;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Globalization;
	using System.Linq;
	#if NUMERICS
	using System.Numerics;
	#endif
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	namespace Aim
	{
		/// <summary>
		/// The BigFlags struct behaves like a Flags enumerated type.
		/// <para>
		/// Note that if this struct will be stored in some type of data
		/// store, it should be stored as a string type. There are two
		/// reasons for this:
		/// </para>
		/// <para>
		/// 1. Presumably, this pattern is being used because the number
		/// of values will exceed 64 (max positions in a long flags enum).
		/// Since this is so, there is in any case no numeric type which
		/// can store all the possible combinations of flags.
		/// </para>
		/// <para>
		/// 2. The "enum" values are assigned based on the order that the
		/// static public fields are defined. It is much safer to store
		/// these fields by name in case the fields are rearranged. This
		/// is particularly important if this represents a permission set!
		/// </para>
		/// </summary>
		[
		TypeConverter( typeof( BigFlagsConverter ) )
		]
		public struct BigFlags : IEquatable<BigFlags>,
			IComparable<BigFlags>, IComparable, IConvertible
		{
			#region State...
			private static readonly List<FieldInfo> Fields;
			private static readonly List<BigFlags> FieldValues;
	#if NUMERICS
			private static readonly bool ZeroInit = true;
			private BigInteger Value;
			/// <summary>
			/// Creates a value taking ZeroInit into consideration.
			/// </summary>
			/// <param name="index"></param>
			/// <returns></returns>
			private static BigInteger CreateValue( int index )
			{
				if( ZeroInit && index == 0 )
				{
					return 0;
				}
				int idx = ZeroInit ? index - 1 : index;
				return new BigInteger( 1 ) << idx;
			}
	#else
			private BitArray Array;
			/// <summary>
			/// Lazy-initialized BitArray.
			/// </summary>
			private BitArray Bits
			{
				get
				{
					if( null == Array )
					{
						Array = new BitArray( Fields.Count );
					}
					return Array;
				}
			}
	#endif
			#endregion ...State
			#region Construction...
			/// <summary>
			/// Static constructor. Sets the static public fields.
			/// </summary>
			static BigFlags()
			{
				Fields = typeof( BigFlags ).GetFields(
					BindingFlags.Public | BindingFlags.Static ).ToList();
				FieldValues = new List<BigFlags>();
				for( int i = 0; i < Fields.Count; i++ )
				{
					var field = Fields[i];
					var fieldVal = new BigFlags();
	#if NUMERICS
					fieldVal.Value = CreateValue( i );
	#else
					fieldVal.Bits.Set( i, true );
	#endif
					field.SetValue( null, fieldVal );
					FieldValues.Add( fieldVal );
				}
			}
			#endregion ...Construction
			#region Operators...
			/// <summary>
			/// OR operator. Or together BigFlags instances.
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			public static BigFlags operator |( BigFlags lhs, BigFlags rhs )
			{
				var result = new BigFlags();
	#if NUMERICS
				result.Value = lhs.Value | rhs.Value;
	#else
				// BitArray is modified in place - always copy!
				result.Array = new BitArray( lhs.Bits ).Or( rhs.Bits );
	#endif
				return result;
			}
			/// <summary>
			/// AND operator. And together BigFlags instances.
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			public static BigFlags operator &( BigFlags lhs, BigFlags rhs )
			{
				var result = new BigFlags();
	#if NUMERICS
				result.Value = lhs.Value & rhs.Value;
	#else
				// BitArray is modified in place - always copy!
				result.Array = new BitArray( lhs.Bits ).And( rhs.Bits );
	#endif
				return result;
			}
			/// <summary>
			/// XOR operator. Xor together BigFlags instances.
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			public static BigFlags operator ^( BigFlags lhs, BigFlags rhs )
			{
				var result = new BigFlags();
	#if NUMERICS
				result.Value = lhs.Value ^ rhs.Value;
	#else
				// BitArray is modified in place - always copy!
				result.Array = new BitArray( lhs.Bits ).Xor( rhs.Bits );
	#endif
				return result;
			}
			/// <summary>
			/// Equality operator.
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			public static bool operator ==( BigFlags lhs, BigFlags rhs )
			{
				return lhs.Equals( rhs );
			}
			/// <summary>
			/// Inequality operator.
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			public static bool operator !=( BigFlags lhs, BigFlags rhs )
			{
				return !( lhs == rhs );
			}
			#endregion ...Operators
			#region System.Object Overrides...
			/// <summary>
			/// Overridden. Returns a comma-separated string.
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
	#if NUMERICS
				if( ZeroInit && Value == 0 )
				{
					return Fields[0].Name;
				}
	#endif
				var names = new List<string>();
				for( int i = 0; i < Fields.Count; i++ )
				{
	#if NUMERICS
					if( ZeroInit && i == 0 )
						continue;
					var bi = CreateValue( i );
					if( ( Value & bi ) ==  bi )
						names.Add( Fields[i].Name );
	#else
					if( Bits[i] )
						names.Add( Fields[i].Name );
	#endif
				}
				return String.Join( ", ", names );
			}
			/// <summary>
			/// Overridden. Compares equality with another object.
			/// </summary>
			/// <param name="obj"></param>
			/// <returns></returns>
			public override bool Equals( object obj )
			{
				if( obj is BigFlags )
				{
					return Equals( (BigFlags)obj );
				}
				return false;
			}
			/// <summary>
			/// Overridden. Gets the hash code of the internal BitArray.
			/// </summary>
			/// <returns></returns>
			public override int GetHashCode()
			{
	#if NUMERICS
				return Value.GetHashCode();
	#else
				int hash = 17;
				for( int i = 0; i < Bits.Length; i++ )
				{
					if( Bits[i] )
						hash ^= i;
				}
				return hash;
	#endif
			}
			#endregion ...System.Object Overrides
			#region IEquatable<BigFlags> Members...
			/// <summary>
			/// Strongly-typed equality method.
			/// </summary>
			/// <param name="other"></param>
			/// <returns></returns>
			public bool Equals( BigFlags other )
			{
	#if NUMERICS
				return Value == other.Value;
	#else
				for( int i = 0; i < Bits.Length; i++ )
				{
					if( Bits[i] != other.Bits[i] )
						return false;
				}
				return true;
	#endif
			}
			#endregion ...IEquatable<BigFlags> Members
			#region IComparable<BigFlags> Members...
			/// <summary>
			/// Compares based on highest bit set. Instance with higher
			/// bit set is bigger.
			/// </summary>
			/// <param name="other"></param>
			/// <returns></returns>
			public int CompareTo( BigFlags other )
			{
	#if NUMERICS
				return Value.CompareTo( other.Value );
	#else
				for( int i = Bits.Length - 1; i >= 0; i-- )
				{
					bool thisVal = Bits[i];
					bool otherVal = other.Bits[i];
					if( thisVal && !otherVal )
						return 1;
					else if( !thisVal && otherVal )
						return -1;
				}
				return 0;
	#endif
			}
			#endregion ...IComparable<BigFlags> Members
			#region IComparable Members...
			int IComparable.CompareTo( object obj )
			{
				if( obj is BigFlags )
				{
					return CompareTo( (BigFlags)obj );
				}
				return -1;
			}
			#endregion ...IComparable Members
			#region IConvertible Members...
			/// <summary>
			/// Returns TypeCode.Object.
			/// </summary>
			/// <returns></returns>
			public TypeCode GetTypeCode()
			{
				return TypeCode.Object;
			}
			bool IConvertible.ToBoolean( IFormatProvider provider )
			{
				throw new NotSupportedException();
			}
			byte IConvertible.ToByte( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToByte( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			char IConvertible.ToChar( IFormatProvider provider )
			{
				throw new NotSupportedException();
			}
			DateTime IConvertible.ToDateTime( IFormatProvider provider )
			{
				throw new NotSupportedException();
			}
			decimal IConvertible.ToDecimal( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToDecimal( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			double IConvertible.ToDouble( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToDouble( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			short IConvertible.ToInt16( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToInt16( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			int IConvertible.ToInt32( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToInt32( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			long IConvertible.ToInt64( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToInt64( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			sbyte IConvertible.ToSByte( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToSByte( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			float IConvertible.ToSingle( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToSingle( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			string IConvertible.ToString( IFormatProvider provider )
			{
				return ToString();
			}
			object IConvertible.ToType( Type conversionType, IFormatProvider provider )
			{
				var tc = TypeDescriptor.GetConverter( this );
				return tc.ConvertTo( this, conversionType );
			}
			ushort IConvertible.ToUInt16( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToUInt16( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			uint IConvertible.ToUInt32( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToUInt32( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			ulong IConvertible.ToUInt64( IFormatProvider provider )
			{
	#if NUMERICS
				return Convert.ToUInt64( Value );
	#else
				throw new NotSupportedException();
	#endif
			}
			#endregion ...IConvertible Members
			#region Public Interface...
			/// <summary>
			/// Checks <paramref name="flags"/> to see if all the bits set in
			/// that flags are also set in this flags.
			/// </summary>
			/// <param name="flags"></param>
			/// <returns></returns>
			public bool HasFlag( BigFlags flags )
			{
				return ( this & flags ) == flags;
			}
			/// <summary>
			/// Gets the names of this BigFlags enumerated type.
			/// </summary>
			/// <returns></returns>
			public static string[] GetNames()
			{
				return Fields.Select( x => x.Name ).ToArray();
			}
			/// <summary>
			/// Gets all the values of this BigFlags enumerated type.
			/// </summary>
			/// <returns></returns>
			public static BigFlags[] GetValues()
			{
				return FieldValues.ToArray();
			}
			/// <summary>
			/// Standard TryParse pattern. Parses a BigFlags result from a string.
			/// </summary>
			/// <param name="s"></param>
			/// <param name="result"></param>
			/// <returns></returns>
			public static bool TryParse( string s, out BigFlags result )
			{
				result = new BigFlags();
				if( String.IsNullOrEmpty( s ) )
					return true;
				var fieldNames = s.Split( ',' );
				foreach( var f in fieldNames )
				{
					var field = Fields.FirstOrDefault( x =>
						String.Equals( x.Name, f.Trim(),
						StringComparison.OrdinalIgnoreCase ) );
					if( null == field )
					{
						result = new BigFlags();
						return false;
					}
	#if NUMERICS
					int i = Fields.IndexOf( field );
					result.Value |= CreateValue( i );
	#else
					result.Bits.Set( Fields.IndexOf( field ), true );
	#endif
				}
				return true;
			}
			//
			// Expose "enums" as public static readonly fields.
			// TODO: Replace this section with your "enum" values.
			//
			public static readonly BigFlags None;
			public static readonly BigFlags FirstValue;
			public static readonly BigFlags ValueTwo;
			public static readonly BigFlags ValueThree;
			public static readonly BigFlags ValueFour;
			public static readonly BigFlags ValueFive;
			public static readonly BigFlags ValueSix;
			public static readonly BigFlags LastValue;
			/// <summary>
			/// Expose flagged combinations as get-only properties.
			/// </summary>
			public static BigFlags FirstLast
			{
				get
				{
					return BigFlags.FirstValue | BigFlags.LastValue;
				}
			}
			#endregion ...Public Interface
		}
		/// <summary>
		/// Converts objects to and from BigFlags instances.
		/// </summary>
		public class BigFlagsConverter : TypeConverter
		{
			/// <summary>
			/// Can convert to string only.
			/// </summary>
			/// <param name="context"></param>
			/// <param name="destinationType"></param>
			/// <returns></returns>
			public override bool CanConvertTo( ITypeDescriptorContext context,
				Type destinationType )
			{
				return destinationType == typeof( String );
			}
			/// <summary>
			/// Can convert from any object.
			/// </summary>
			/// <param name="context"></param>
			/// <param name="sourceType"></param>
			/// <returns></returns>
			public override bool CanConvertFrom( ITypeDescriptorContext context,
				Type sourceType )
			{
				return true;
			}
			/// <summary>
			/// Converts BigFlags to a string.
			/// </summary>
			/// <param name="context"></param>
			/// <param name="culture"></param>
			/// <param name="value"></param>
			/// <param name="destinationType"></param>
			/// <returns></returns>
			public override object ConvertTo( ITypeDescriptorContext context,
				CultureInfo culture, object value, Type destinationType )
			{
				if( value is BigFlags && CanConvertTo( destinationType ) )
					return value.ToString();
				return null;
			}
			/// <summary>
			/// Attempts to parse <paramref name="value"/> and create and
			/// return a new BigFlags instance.
			/// </summary>
			/// <param name="context"></param>
			/// <param name="culture"></param>
			/// <param name="value"></param>
			/// <returns></returns>
			public override object ConvertFrom( ITypeDescriptorContext context,
				CultureInfo culture, object value )
			{
				var s = Convert.ToString( value );
				BigFlags result;
				BigFlags.TryParse( s, out result );
				return result;
			}
		}
	}
