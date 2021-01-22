	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;
	using System.Resources;
	namespace NMatrix
	{
		[DebuggerDisplay("{Value} ({Name})")]
		public abstract class RichEnum<TValue, TDerived>
					: IEquatable<TDerived>,
					  IComparable<TDerived>,
					  IComparable, IComparer<TDerived>
			where TValue : struct, IComparable<TValue>, IEquatable<TValue>
			where TDerived : RichEnum<TValue, TDerived>
		{
			#region Backing Fields
			/// <summary>
			/// The value of the enum item
			/// </summary>
			public readonly TValue Value;
			/// <summary>
			/// The public field name, determined from reflection
			/// </summary>
			private string _name;
			/// <summary>
			/// The DescriptionAttribute, if any, linked to the declaring field
			/// </summary>
			private DescriptionAttribute _descriptionAttribute;
			/// <summary>
			/// Reverse lookup to convert values back to local instances
			/// </summary>
			private static readonly SortedList<TValue, TDerived> _values = new SortedList<TValue, TDerived>();
			#endregion
			#region Constructors
			protected RichEnum(TValue value)
			{
				this.Value = value;
				_values.Add(value, (TDerived)this);
			}
			#endregion
			#region Properties
			public string Name
			{
				get
				{
					return _name;
				}
			}
			public string Description
			{
				get
				{
					if (_descriptionAttribute != null)
						return _descriptionAttribute.Description;
					return _name;
				}
			}
			#endregion
			#region Initialization
			static RichEnum()
			{
				var fields = typeof(TDerived)
					.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
					.Where(t => t.FieldType == typeof(TDerived));
				foreach (var field in fields)
				{
					/*var dummy =*/ field.GetValue(null); // forces static initializer to run for TDerived
					TDerived instance = (TDerived)field.GetValue(null);
					instance._name = field.Name;
                                        instance._descriptionAttribute = field.GetCustomAttributes(true).OfType<DescriptionAttribute>().FirstOrDefault();
				}
			}
			#endregion
			#region Conversion and Equality
			public static TDerived Convert(TValue value)
			{
				return _values[value];
			}
			public static bool TryConvert(TValue value, out TDerived result)
			{
				return _values.TryGetValue(value, out result);
			}
			public static implicit operator TValue(RichEnum<TValue, TDerived> value)
			{
				return value.Value;
			}
			public static implicit operator RichEnum<TValue, TDerived>(TValue value)
			{
				return _values[value];
			}
			public static implicit operator TDerived(RichEnum<TValue, TDerived> value)
			{
				return value;
			}
			public override string ToString()
			{
				return _name;
			}
			#endregion
			#region IEquatable<TDerived> Members
			public override bool Equals(object obj)
			{
				if (obj != null)
				{
					if (obj is TValue)
						return Value.Equals((TValue)obj);
					if (obj is TDerived)
						return Value.Equals(((TDerived)obj).Value);
				}
				return false;
			}
			bool IEquatable<TDerived>.Equals(TDerived other)
			{
				return Value.Equals(other.Value);
			}
			public override int GetHashCode()
			{
				return Value.GetHashCode();
			}
			#endregion
			#region IComparable Members
			int IComparable<TDerived>.CompareTo(TDerived other)
			{
				return Value.CompareTo(other.Value);
			}
			int IComparable.CompareTo(object obj)
			{
				if (obj != null)
				{
					if (obj is TValue)
						return Value.CompareTo((TValue)obj);
					if (obj is TDerived)
						return Value.CompareTo(((TDerived)obj).Value);
				}
				return -1;
			}
			int IComparer<TDerived>.Compare(TDerived x, TDerived y)
			{
				return (x == null) ? -1 :
					   (y == null) ? 1 :
						x.Value.CompareTo(y.Value);
			}
			#endregion
			public static IEnumerable<TDerived> Values
			{
				get
				{
					return _values.Values;
				}
			}
			public static TDerived Parse(string name)
			{
				foreach (TDerived value in Values)
					if (0 == string.Compare(value.Name, name, true))
						return value;
				return null;
			}
		}
	}
