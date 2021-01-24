        public ParentClass[] PMI(string Id)  
    {
        return new ParentClass[]
        {
            new ParentClass
			{
				new Information
				{
					Name = "First|Last",
					NameId = "1",
					Allowed = true,
					date = "Feb 1, 2018",
					EndTime = "1:00 PM",
					DateTime = "09:00"
				},
				new Settings
				{
					id = 1,
					name = "TestName",
					maxValue = "1000"
				}
			}
        };
    }
	
