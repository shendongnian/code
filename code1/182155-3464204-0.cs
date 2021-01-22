	public class CloneableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public IDictionary<TKey, TValue> Clone()
		{
			var clone = new CloneableDictionary<TKey, TValue>();
			foreach (KeyValuePair<TKey, TValue> pair in this)
			{
				ICloneable clonableValue = pair.Value as ICloneable;
				if (clonableValue != null)
					clone.Add(pair.Key, (TValue)clonableValue.Clone());
				else
					clone.Add(pair.Key, pair.Value);
			}
			return clone;
		}
	}
