    using(var ctx = new DataServiceContext(...){MergeOption = OverwriteChanges})
    {
    	from c in ctx.Customers
    	select new Customer
    	{
    		Order = new Order
    		{
    			Item = new Item
    			{
    				Id = c.Order.Item.Id,
    				Description = c.Order.Item.Description
    			}
    		}
    		
    	}
    }
