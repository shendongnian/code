		public static IList<Content> GetAllContentByTags(IList<Tag> tags) {
			IQueryable<Content> contentQuery = ...
			Expression<Func<Content, bool>> predicate = PredicateBuilder.False<Content>();
			foreach (Tag individualTag in tags) {
				Tag tagParameter = individualTag;
				predicate = predicate.Or(p => p.Tags.Any(tag => tag.Name.Equals(tagParameter.Name)));
			}
			IQueryable<Content> resultExpressions = contentQuery.Where(predicate);
			
			return resultExpressions.ToList();
		}
