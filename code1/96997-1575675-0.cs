	public static T Clone<T>(T input, params object[] stableReferences)
	{
		Dictionary<object, object> graph = new Dictionary<object, object>(new ReferenceComparer());
		foreach (object o in stableReferences)
			graph.Add(o, o);
		return InternalClone(input, graph);
	}
