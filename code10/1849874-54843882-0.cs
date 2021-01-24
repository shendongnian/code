	var tasks = events.Select(async entity =>
	{
		await Task.Run(() => Context.Entry(entity).Property(x => x.Attendance).IsModified = true);
		await Context.SaveChangesAsync();
	});
	await Task.WhenAll(tasks);
