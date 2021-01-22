        	List<DateTime> list = new List<DateTime> ();
			list.Add (DateTime.Parse ("2002 Jan 01"));
			list.Add (DateTime.Parse ("2003 Jan 01"));
			list.Add (DateTime.Parse ("2004 Jan 01"));
			list.Add (DateTime.Parse ("2005 Jan 01"));
			list.Add (DateTime.Parse ("2004 Jan 01"));
			list.Add (DateTime.Parse ("2004 Jan 01"));
			list.Add (DateTime.Parse ("2007 Jan 01"));
			int year = list.Select (d => d.Year)
				.GroupBy (y => y)
				.OrderBy (g => g.Count ())
				.Last ()
				.Key;
