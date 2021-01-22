    	[Association(Name="CustomerStatus_Customer", Storage="_CustomerStatus", ThisKey="CustomerStatusId", OtherKey="CustomerStatusId", IsForeignKey=true)]
        [DataMember()]
		public CustomerStatus CustomerStatus
		{
			get
			{
				return this._CustomerStatus.Entity;
			}
			set
			{ 
              ...
             }
         }
