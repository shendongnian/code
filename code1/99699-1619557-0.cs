		static IDictionary<TKey, TValue> NewDictionary<TKey, TValue>(TKey key, TValue value)
		{
			return new Dictionary<TKey, TValue>();
		}
		static void Main(string[] args)
		{
			var dict = NewDictionary(new {ID = 1}, new { Column = "Dollar", Localized = "Доллар" });
		}
