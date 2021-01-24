	public static class EnumerableContractsExtensions
	{
		public static IEnumerable<Contract> SignedBetween(this IEnumerable<Contract> contracts, DateTime start, DateTime end)
		{
			return contracts.Where(x => x.SignDate.IsBetween(start, end));
		}
	}
