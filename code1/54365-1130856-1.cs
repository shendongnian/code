	public class Account: IAccount
	{
		public virtual long AccountId { get; internal set; }
		public virtual IHouse House { get; internal set; }
	}
	public class House: IHouse
	{
		public virtual long HouseId { get; internal set; }
		public virtual HouseStatus Status { get; internal set; }
		public virtual IList<IAccount> Accounts { get; internal set; }
	}
