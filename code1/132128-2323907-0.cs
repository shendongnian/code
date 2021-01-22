		private static Dictionary<object,object> DeTypeDictionary<T,U>(Dictionary<T,U> inputDictionary)
		{
			Dictionary<object, object> returnDictionary = new Dictionary<object, object>();
			foreach(T key in inputDictionary.Keys)
			{
				if( (key is object) && (inputDictionary[key] is object))
				{
					returnDictionary.Add(key, inputDictionary[key]);
				}
				else
				{
					//sorry these aren't objects. they may be dynamics.
					continue;
				}
				
			}
			return returnDictionary;
		}
