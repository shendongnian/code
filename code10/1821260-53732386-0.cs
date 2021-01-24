	public static async Task Remove(int id)
	{
		using (var ctx = new StoreContext())
		{
			var product = new Product { ID = id};
			ctx.Products.Attach(product);
			ctx.Products.Remove(product);
			await ctx.SaveChangesAsync();
		}
	}
