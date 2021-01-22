		private List<groupFoo> groupFoos(List<foo> foos)
		{
			
			//Group by Day into groupFoo
			var z = foos.GroupBy(a => a.FooDate.ToShortDateString()).Select(x => new groupFoo() { Key = x.Key, Start = x.First().FooDate, End = x.Last().FooDate }).ToList();
			//Create new list to hold groups
			var groupedFoos = new List<groupFoo>();
			//add all the good groups to the list
			groupedFoos.AddRange(z.FindAll(zz => zz.Start.CompareTo(zz.End) != 0));
			//Remove all of the good groups from the orignal list
			groupedFoos.ForEach(gf => z.RemoveAt(z.IndexOf(gf)));
			//Sort whats left
			z.Sort((a, b) => { return a.Start.CompareTo(b.Start); });
			
			while (z.Count > 1)
			{
				//grab the first 2 
				var y = z.Take(2);
				//create a new group foo and add it to the good list
				groupedFoos.Add(y.Aggregate((a, b) => new groupFoo() { Key = a.Key, Start = a.Start, End = b.End }));
				//remove the bad ones
				y.ToList().ForEach(yy => z.RemoveAt(z.IndexOf(yy)));
			}
			return groupedFoos;
		}
