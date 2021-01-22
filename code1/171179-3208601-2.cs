    public void GroupTest()
    		{
    			// Create some data to work with.
    			List<CustomRowType> testData = new List<CustomRowType>();
    			testData.Add(new CustomRowType() { ID = 1, Subscriber = "Subscriber 1", SubscribedTo = 40 });
    			testData.Add(new CustomRowType() { ID = 2, Subscriber = "Subscriber 2", SubscribedTo = 1 });
    			testData.Add(new CustomRowType() { ID = 3, Subscriber = "Subscriber 3", SubscribedTo = 2 });
    			testData.Add(new CustomRowType() { ID = 4, Subscriber = "Subscriber 4", SubscribedTo = 2 });
    			
    
    			// Using query syntax
    			var grp = (
    				from d in testData
    				group d by d.SubscribedTo into g
    				select g
    			);
    				
    			
    			var output = grp
    				// Filter
    				.Where(g => g.Count() > 1)
    				// Flatten group data (equivalent to SELECT clause)
    				.SelectMany(g => g
    					.Select(d => d.ID.ToString() + "(" + d.Subscriber + ") -> " + d.SubscribedTo.ToString()+" with (" + g.Key.ToString() + ") total subscriptions" ))
    				.ToList();
    				
    			listBox1.Items.Clear();
    			output.ForEach(s => listBox1.Items.Add(s));
    			
    		}
