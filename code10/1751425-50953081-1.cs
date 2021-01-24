    var result = col.FindOneAndUpdateAsync<Person>(
	                   x => x.Title == person.Title && x.Name == person.Name && x.ReceivedAt <= person.ReceivedAt + TimeSpan.FromMinutes(1),
	                   Builders<Person>.Update.Combine(),
	                   new FindOneAndUpdateOptions<Person>() { IsUpsert = true })
                   .GetAwaiter().GetResult(); // or await in front of invocation
