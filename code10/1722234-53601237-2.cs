	registrationHelper.RegisterMigrationContext<Database.Db_MSSQL>(API_Name.MyAPI, DataBaseProviderName.MSSQL);
	registrationHelper.RegisterMigrationContext<Database.Db_MySQL>(API_Name.MyAPI, DataBaseProviderName.MySQL);
	registrationHelper.RegisterDbContextOptions<DbContextOptions_MSSQL>(DataBaseProviderName.MSSQL);
    registrationHelper.RegisterDbContextOptions<DbContextOptions_MySQL>(DataBaseProviderName.MySQL);	
	
