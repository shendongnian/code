private static IEnumerable<int> Primes01(int num)
{
	return Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(num))))
		.Aggregate(Enumerable.Range(1, num).ToList(),
		(result, index) =>
			{
				result.RemoveAll(i => i > result[index] && i%result[index] == 0);
				return result;
			}
		);
}
The seed of the Aggregate should be range 1 to num since this list will contain the final list of primes.  The Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(num)))) is the number of times the seed is purged.
