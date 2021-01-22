			public static List<RelevanceTableEntry> CreateRelevanceTable(List<queryTerm> queryTerms)
				{
				SearchDataContext myContext = new SearchDataContext();
				var productRelevance = (from pwords in myContext.SearchWordOccuranceProducts
				where (myContext.SearchUniqueWords
				.Where (searchWord => queryTerms.Contains(searchWord.Word))
				.Select (searchWord => searchWord.Id)).Contains(pwords.WordId)
				orderby pwords.WordId
				select new {pwords.WordId, pwords.Weight, pwords.Position, pwords.ProductId});
				}
