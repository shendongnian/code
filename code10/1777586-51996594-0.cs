	void Main()
	{
		DataTable dt = new DataTable();
		dt.Columns.Add("ID", typeof(Int32));
		dt.Columns.Add("First Name");
		dt.Columns.Add("LAST NAME");
		dt.Columns.Add("STATE");
		dt.Columns.Add("ADDRESS");
		dt.Columns.Add("ZIP CODE");
		dt.Columns.Add("TELEPHONE NUMBER");
		dt.Rows.Add(1, "John", "Hill", "NY", "5 Street", "");
		dt.Rows.Add(2, "John", "Hill", "NY", "11 East", "15543", "(846)456-7655");
		dt.Rows.Add(3, "John", "Hill", "NY", "", "98777", "");
		dt.Rows.Add(4, "John", "Hill", "NY", "34 West", "", "");
		dt.Rows.Add(5, "Mary", "Frey", "IL", "45 South", "", "765655-45444");
	
	
		dt.Rows.Cast<DataRow>()
			.GroupBy(d => new 
				{ 
					First = d.Field<String>("First Name"), 
					LastName = d.Field<String>("Last Name"), 
					State = d.Field<String>("State")
				})
			.Select(d => d.OrderByDescending(x => x.Field<Int32>("ID")))
			.Select(d => new { 
				Latest = d.First(), 
				Columns = Enumerable
					.Range(4, d.First().Table.Columns.Count - 4)
					.Select(r => d.Select(x => new {Name = d.First().Table.Columns[r].ColumnName, Data= x.Field<String>(r)}).Where(x => !String.IsNullOrWhiteSpace(x.Data))) })
			.Select(d =>
				{
					d.Columns.Where(x => x.Any()).ToList().ForEach(c => d.Latest[c.First().Name] = c.First().Data);
					return d.Latest;
				});
	}
