		public static IEnumerable<Article> TicArticles
		{
			get
			{
				ObjectCache cache = MemoryCache.Default;
				if (cache["TicArticles"] == null)
				{
					CacheItemPolicy policy = new CacheItemPolicy();
					using(TicDatabaseEntities db = new TicDatabaseEntities())
					{
						IEnumerable<Article> articles = (from a in db.Articles select a).ToList();
						cache.Set("TicArticles", articles, policy);
					}
				}
				return (IEnumerable<Article>)MemoryCache.Default["TicArticles"];
			}
		}
		private static bool TicArticleExists(string supplierIdent)
		{
			if (TicArticles.Count(p => p.SupplierArticleID.Equals(supplierIdent)) > 0)
				return true;
			return false;
		}
