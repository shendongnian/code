	Dictionary<string, Foo> map =
		typeof(Foo)
			.GetEnumValues()
			.Cast<Foo>()
			.Zip(
				typeof(Foo)
					.GetEnumValues()
					.Cast<int>(),
				(n, v) => new { n, v })
			.ToDictionary(x => x.n.ToString(), x => (Foo)x.v);
	
	Console.WriteLine((int)map["Bar"]);
	Console.WriteLine((int)map["Qaz"]);
