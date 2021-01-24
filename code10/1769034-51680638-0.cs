	IObservable<string> query =
		from t in Observable.Interval(TimeSpan.FromMilliseconds(PollIntervalMilliseconds))
		from x in Observable.Using(
			() => new SqlConnection(ConnectionString),
			dbConnection =>
				Observable.Using(
					() =>
					{
						var c = new SqlCommand("marc.GetEvents", dbConnection);
						c.CommandType = CommandType.StoredProcedure;
						c.Parameters.AddWithValue("@fromId", lastEventId);
						return c;
					},
					command =>
						from o in Observable.FromAsync(() => command.Connection.OpenAsync())
						from reader in Observable.FromAsync(() => command.ExecuteReaderAsync(topToken))
						let received = lastEventId
						from r in Observable.FromAsync(() => reader.ReadAsync(topToken))
						select reader.GetFieldValue<string>(0)))
		select x;
