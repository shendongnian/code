	public static bool FieldsEquals(this object o1, object o2)
	{
		if (ReferenceEquals(o1, o2))
			return true;
		if (o1 == null || o2 == null || o1.GetType() != o2.GetType())
			return false;
		if (o1 is IEnumerable enumerable1 && o2 is IEnumerable enumerable2)
		{
			var enumerator1 = enumerable1.GetEnumerator();
            var enumerator2 = enumerable2.GetEnumerator();
            while(enumerator1.MoveNext())
            {
                if (!enumerator2.MoveNext())
                {
                    return false;
                }
                if (!enumerator1.Current.FieldsEquals(enumerator2.Current))
                {
                    return false;
                }
            }
		}
		else
		{
			foreach (var f in o1.GetType().GetFields())
			{
				var val1 = f.GetValue(o1);
				var val2 = f.GetValue(o2);
				if (val1 == null || val2 == null) continue;
				if (val1 is IEnumerable e1 && val2 is IEnumerable e2)
				{
					if (!e1.FieldsEquals(e2))
					{
						return false;
					}
				}
				else
				{
					if (!val1.Equals(val2))
					{
						return false;
					}
				}
			}
		}
		return true;
	}
