		public void GroupTest()
		{
			// Create some data to work with.
			List<CustomRowType> testData = new List<CustomRowType>();
			testData.Add(new CustomRowType() { ID = 1, Subscriber = "Subscriber 1", SubscribedTo = 40 });
			testData.Add(new CustomRowType() { ID = 2, Subscriber = "Subscriber 2", SubscribedTo = 1 });
			testData.Add(new CustomRowType() { ID = 3, Subscriber = "Subscriber 3", SubscribedTo = 2 });
			testData.Add(new CustomRowType() { ID = 4, Subscriber = "Subscriber 4", SubscribedTo = 2 });
			
			// Group data (equivalent to GROUP BY clause)
			var grp = testData.GroupBy(
				row => row.SubscribedTo,
				(key, row) => new
				{
					Data = row,
					// Here is the aggregate value
					KeyCount = testData.Count(i => i.SubscribedTo == key)	
				}
			);
			
			var output = grp
				// Filter group data (equivilent to HAVING clause)
				.Where(g => g.KeyCount > 1)	// Remove this line to see all aggregate data.
				// Flatten group data (equivalent to SELECT clause)
				.SelectMany(g => g.Data
					.Select(d => d.ID.ToString() + "(" + d.Subscriber + ") -> " + d.SubscribedTo.ToString()+" with (" + g.KeyCount.ToString() + ") total subscriptions" ))
				.ToList();
				
			listBox1.Items.Clear();
			output.ForEach(s => listBox1.Items.Add(s));
			
		}
