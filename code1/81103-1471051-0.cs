    public class RetryTurnElement : ConfigurationElement
	{
		public RetryTurnElement()
		{
			UniqueId = Guid.NewGuid();
		}
		internal Guid UniqueId { get; set; }
		...
	}
