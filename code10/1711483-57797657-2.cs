	// Assert something
	using (var context = DbContextFactory.Create())
	{
		var myEntitySet = context.MyEntities.ToArray();
		myEntitySet.Should().BeEquivalentTo(expectedEntities, options => options
			.IncludingPersistentProperties(context)
			.Excluding(r => r.MyPrimaryKey));
	}
