			using (var dbc = new siteDataContext())
			{
				dbc.Log = Console.Out;
				var bd = (from b in dbc.birthdays
						 select b).Count();
				Console.WriteLine("{0}", bd);
            }
