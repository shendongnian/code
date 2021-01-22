	var instances = new List<Data>() {
		new Data() {
			Name = "Two",
			Date = new DateTime(1998, 1, 1)
		},
		new Data() {
			Name = "Two",
			Date = new DateTime(1997, 1, 1)
		},
		new Data() {
			Name = "One",
			Date = new DateTime(1998, 1, 1)
		},
		new Data() {
			Name = "One",
			Date = new DateTime(1997, 1, 1)
		},
		new Data() {
			Name = "Three",
			Date = new DateTime(1998, 1, 1)
		},
		new Data() {
			Name = "Three",
			Date = new DateTime(1997, 1, 1)
		}
	};
	
	var groupedMax = from i in instances
		group i by i.Name into g
		select new Data() {
			Name = g.Key, 
			Date = g.Max(i => i.Date)
		};
----------
    public class Data
    {
    	public string Name { get; set; }
    	public DateTime Date { get; set; }
    }
