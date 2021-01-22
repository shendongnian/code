        public IEnumerable<IResult> ExecuteSearch()
        {
            var search = new SearchGames
            {
                SearchText = SearchText
            }.AsResult();
            yield return Show.Busy();
            yield return search;
            var resultCount = search.Response.Count();
            if (resultCount == 0)
                SearchResults = _noResults.WithTitle(SearchText);
            else if (resultCount == 1 && search.Response.First().Title == SearchText)
            {
                var getGame = new GetGame
                {
                    Id = search.Response.First().Id
                }.AsResult();
                yield return getGame;
                yield return Show.Screen<ExploreGameViewModel>()
                    .Configured(x => x.WithGame(getGame.Response));
            }
            else SearchResults = _results.With(search.Response);
            yield return Show.NotBusy();
        }
