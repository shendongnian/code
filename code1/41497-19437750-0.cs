    public void ConfigureSearch(ISearchConfiguration config)
		{
			config.AddGlobalSearchCallback<IEmploymentDataContext>((query, ctx) =>
			{
				return ctx.Positions.Where(p => p.Name.Contains(query)).ToList().Select(p =>
					new SearchResult("Positions", p.Name, p.ThumbnailUrl,
						new UrlContext("edit", "position", new RouteValueDictionary(new { Id = p.Id }))
						));
			});
		}
