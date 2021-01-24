    public static void AddIfNotNullAndInAdvancedSearch(
            this List<TreeDocument> docs,
            TreeDocument value,
            params SearchModel[] searchCriteria)
        {
            var filteredSearchCriteria = searchCriteria
                .Where(x => x.SearchResult != "No Match" &&
                            x.SearchResult != "Empty")
                .ToList();
            if (filteredSearchCriteria.Any() && 
                filteredSearchCriteria.All(x => x.SearchResult == "Match"))
            {
                docs.Add(value);
            }
        }
