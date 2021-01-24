	var context = Injectivity.Context.CreateRoot();
	context.SetConfig<string>("dbKey", "sqlserver?");
	context.SetFactory<IDbManager, DbManager>();
	context.SetFactory<IRepositoryDal<User>, UserRepositoryDal>();
	context.SetFactory<UserBal, UserBal>();
	
	var user = context.Resolve<UserBal>();
