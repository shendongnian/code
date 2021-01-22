    I had a same problem, after waste a little time in stackoverflow ;-), change my code to this:
    public List<string> ListofNewsTitle()
            {
                var query = from n in db.NewsEvents
                            orderby n.NewsDate descending
                            select n.NewsTitle;
                return query.ToList();
        
            }
