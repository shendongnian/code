    public static List<object[]> GetCombinationsFromIEnumerables(ref object[] chain, ref IEnumerable<IEnumerable<object>> IEnumerables)
    {
	List<object[]> Combinations = new List<object[]>();
	if (IEnumerables.Any) {
		foreach ( v in IEnumerables.First) {
			Combinations.AddRange(GetCombinationsFromIEnumerables(chain.Concat(new object[] { v }).ToArray, IEnumerables.Skip(1)).ToArray);
		}
	} else {
		Combinations.Add(chain);
	}
	return Combinations;
    }
    public static List<object[]> GetCombinationsFromIEnumerables(params IEnumerable<object>[] IEnumerables)
    {
	return GetCombinationsFromIEnumerables(chain = new object[], IEnumerables = IEnumerables.AsEnumerable);
    }
