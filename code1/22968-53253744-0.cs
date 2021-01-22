	/// <summary>
	/// Based on: https://stackoverflow.com/a/42264037/6155481
	/// </summary>
	public class ObjectDumper
	{
		public static string Dump(object obj)
		{
			return new ObjectDumper().DumpObject(obj);
		}
		StringBuilder _dumpBuilder = new StringBuilder();
		string DumpObject(object obj)
		{
			DumpObject(obj, 0);
			return _dumpBuilder.ToString();
		}
		void DumpObject(object obj, int nestingLevel)
		{
			var nestingSpaces = "".PadLeft(nestingLevel * 4);
			if (obj == null)
			{
				_dumpBuilder.AppendFormat("{0}null\n", nestingSpaces);
			}
			else if (obj is string || obj.GetType().GetTypeInfo().IsPrimitive || obj.GetType().GetTypeInfo().IsEnum)
			{
				_dumpBuilder.AppendFormat("{0}{1}\n", nestingSpaces, obj);
			}
			else if (ImplementsDictionary(obj.GetType()))
			{
				using (var e = ((dynamic)obj).GetEnumerator())
				{
					var enumerator = (IEnumerator)e;
					while (enumerator.MoveNext())
					{
						dynamic p = enumerator.Current;
						var key = p.Key;
						var value = p.Value;
						_dumpBuilder.AppendFormat("{0}{1} ({2})\n", nestingSpaces, key, value != null ? value.GetType().ToString() : "<null>");
						DumpObject(value, nestingLevel + 1);
					}
				}
			}
			else if (obj is IEnumerable)
			{
				foreach (dynamic p in obj as IEnumerable)
				{
					DumpObject(p, nestingLevel);
				}
			}
			else
			{
				foreach (PropertyInfo descriptor in obj.GetType().GetRuntimeProperties())
				{
					string name = descriptor.Name;
					object value = descriptor.GetValue(obj);
					_dumpBuilder.AppendFormat("{0}{1} ({2})\n", nestingSpaces, name, value != null ? value.GetType().ToString() : "<null>");
					// TODO: Prevent recursion due to circular reference
					if (name == "Self" && HasBaseType(obj.GetType(), "NSObject"))
					{
						// In ObjC I need to break the recursion when I find the Self property
						// otherwise it will be an infinite recursion
						Console.WriteLine($"Found Self! {obj.GetType()}");
					}
					else
					{
						DumpObject(value, nestingLevel + 1);
					}
				}
			}
		}
		
		bool HasBaseType(Type type, string baseTypeName)
		{
			if (type == null) return false;
			string typeName = type.Name;
			
			if (baseTypeName == typeName) return true;
			return HasBaseType(type.GetTypeInfo().BaseType, baseTypeName);
		}
		bool ImplementsDictionary(Type t)
		{
			return t is IDictionary;
		}
	}
