	public async Task<IEnumerable<T>> GetUnion<T>(Task<IEnumerable<T>> a, Task<IEnumerable<T>> b)
	{
		await Task.WhenAll(a,b);
		return a.Result.Union(b.Result);
	}
