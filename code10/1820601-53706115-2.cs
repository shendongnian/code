    IQueryable<FoodDto> QueryFood(string rule, string query)
    {
        return this.selectInfos
            .Where(selectInfo => selectInfo.Rule(rule))
            .Select(selectInfo => selectInfo.ReturnSearchResult(query);
    }
    IEnumerable<FootDto> SelectFood(string rule, string query)
    {
         return this.QueryFood(rule, query).AsEnumerable();
    }
