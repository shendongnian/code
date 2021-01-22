	public interface IAccount
	{
		long AccountId { get; }
		IHouse House { get; }
	}
	public interface IHouse
	{
		long HouseId { get; }
		HouseStatus Status { get; }
		IList<IAccount> Accounts { get; }
	}
