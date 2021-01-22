	MyDogs.Execute(items =>
	{
		items.Clear();
		items.AddRange(Context.Dogs);
		items.Insert(0, new Dog { Id = 0, Name = "All Dogs" });
	});
