    // In the lower level project (or DLL)...
    public abstract class BaseEnums
	{
		public enum ImportanceType
		{
			None = 0,
			Success = 1,
			Warning = 2,
			Information = 3,
			Exclamation = 4
		}
		[Flags]
		public enum StatusType : Int32
		{
			None = 0,
			Pending = 1,
			Approved = 2,
			Canceled = 4,
			Accepted = (8 | Approved),
			Rejected = 16,
			Shipped = (32 | Accepted),
			Reconciled = (64 | Shipped)
		}
		public enum Conveyance
		{
			None = 0,
			Feet = 1,
			Automobile = 2,
			Bicycle = 3,
			Motorcycle = 4,
			TukTuk = 5,
			Horse = 6,
			Yak = 7,
			Segue = 8
		}
