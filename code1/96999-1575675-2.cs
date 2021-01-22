	private static T InternalClone<T>(T input, Dictionary<object, object> graph)
	{
		if (input == null || input is string || input.GetType().IsPrimitive)
			return input;
		Type inputType = input.GetType();
		object exists;
		if (graph.TryGetValue(input, out exists))
			return (T)exists;
		
		if (input is Array)
		{
			Array arItems = (Array)((Array)(object)input).Clone();
			graph.Add(input, arItems);
			for (long ix = 0; ix < arItems.LongLength; ix++)
				arItems.SetValue(InternalClone(arItems.GetValue(ix), graph), ix);
			return (T)(object)arItems;
		}
		else if (input is Delegate)
		{
			Delegate original = (Delegate)(object)input;
			Delegate result = null;
			foreach (Delegate fn in original.GetInvocationList())
			{
				Delegate fnNew;
				if (graph.TryGetValue(fn, out exists))
					fnNew = (Delegate)exists;
				else
				{
					fnNew = Delegate.CreateDelegate(input.GetType(), InternalClone(original.Target, graph), original.Method, true);
					graph.Add(fn, fnNew);
				}
				result = Delegate.Combine(result, fnNew);
			}
			graph.Add(input, result);
			return (T)(object)result;
		}
		else
		{
			Object output = FormatterServices.GetUninitializedObject(inputType);
			if (!inputType.IsValueType)
				graph.Add(input, output);
			MemberInfo[] fields = inputType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			object[] values = FormatterServices.GetObjectData(input, fields);
			for (int i = 0; i < values.Length; i++)
				values[i] = InternalClone(values[i], graph);
			FormatterServices.PopulateObjectMembers(output, fields, values);
			return (T)output;
		}
	}
