    public override List<Item> SearchListWithSearchPhrase(string searchPhrase)
    {
        List<string> searchTerms = StringHelpers.GetSearchTerms(searchPhrase);
        using (var db = Datasource.GetContext())
        {
            IQueryable<Task> taskQuery = db.Tasks.AsQueryable();
            foreach(var term in searchTerms)
            {
                  taskQuery = taskQuery.Where(t=>t.Title.ToUpper().Contains(term.ToUpper()) && t.Description.ToUpper().Contains(term.ToUpper()))            
            }
            return taskQuery.ToList();
        }
    }
