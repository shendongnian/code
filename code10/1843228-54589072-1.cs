		@{
			Elements item = new Elements();
			if (dictionaryOfElements.TryGetValue(4, out item))
			{
				<p>
					item.AtomicNumber
					item.Symbol
					item.Name
					item.Weight
				</p>
			}
		};
