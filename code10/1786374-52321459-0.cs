	public async Task<IEnumerable<User>> Get()
	{
		List<User> users = await MongoDataModel.Instance.GetUsers(MongoDataModel.Instance.CurrentMongoDB);
		TestMethod();
		return users;
	}
