		private static PledgeManagerEntities pledgesEntities;
		public static PledgeManagerEntities PledgeManagerEntities
		{
			get 
			{
				if (pledgesEntities == null)
				{
					pledgesEntities = new PledgeManagerEntities();
				}
				return pledgesEntities; 
			}
			set { pledgesEntities = value; }
		}
