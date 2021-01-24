	public static class EnumerableContractsExtensions
	{
		public static IEnumerable<Contract> Between(this IEnumerable<Contract> contracts, Func<Contract, DateTime> selector, DateTime start, DateTime end)
		{
			return contracts.Where(x => selector(x).IsBetween(start, end));
		}
        }
