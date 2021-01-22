	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Reflection;
	namespace Tools.Reflection
	{
		public interface IPropertyAccessor
		{
			PropertyInfo PropertyInfo { get; }
			object GetValue(object source);
			void SetValue(object source, object value);
		}
		public static class PropertyInfoHelper
		{
			private static ConcurrentDictionary<PropertyInfo, IPropertyAccessor> _cache =
				new ConcurrentDictionary<PropertyInfo, IPropertyAccessor>();
			public static IPropertyAccessor GetAccessor(PropertyInfo propertyInfo)
			{
				IPropertyAccessor result = null;
				if (!_cache.TryGetValue(propertyInfo, out result))
				{
					result = CreateAccessor(propertyInfo);
					_cache.TryAdd(propertyInfo, result); ;
				}
				return result;
			}
			public static IPropertyAccessor CreateAccessor(PropertyInfo PropertyInfo)
			{
				var GenType = typeof(PropertyWrapper<,>)
					.MakeGenericType(PropertyInfo.DeclaringType, PropertyInfo.PropertyType);
				return (IPropertyAccessor)Activator.CreateInstance(GenType, PropertyInfo);
			}
		}
		internal class PropertyWrapper<TObject, TValue> : IPropertyAccessor where TObject : class
		{
			private Func<TObject, TValue> Getter;
			private Action<TObject, TValue> Setter;
			public PropertyWrapper(PropertyInfo PropertyInfo)
			{
				this.PropertyInfo = PropertyInfo;
				MethodInfo GetterInfo = PropertyInfo.GetGetMethod(true);
				MethodInfo SetterInfo = PropertyInfo.GetSetMethod(true);
				Getter = (Func<TObject, TValue>)Delegate.CreateDelegate
						(typeof(Func<TObject, TValue>), GetterInfo);
				Setter = (Action<TObject, TValue>)Delegate.CreateDelegate
						(typeof(Action<TObject, TValue>), SetterInfo);
			}
			object IPropertyAccessor.GetValue(object source)
			{
				return Getter(source as TObject);
			}
			void IPropertyAccessor.SetValue(object source, object value)
			{
				Setter(source as TObject, (TValue)value);
			}
			public PropertyInfo PropertyInfo { get; private set; }
		}
	}
