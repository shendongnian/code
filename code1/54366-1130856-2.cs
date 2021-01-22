	public sealed class AccountMap : ClassMap<IAccount>
	{
		public PokerPlayerMap()
		{
			Id(x => x.AccountId, "account_id");
			DiscriminateSubClassesOnColumn("Type").SubClass<Account>(s =>  
			{
				References(x => x.House);		
			});
		}
	}
