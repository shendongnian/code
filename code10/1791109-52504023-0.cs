    public static class MappingProfile
	{
		public static MapperConfiguration InitializeAutoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<tblPersonnel, PersonnelDetailsVm>();
			});
			return config;
		} 
	}
    	
