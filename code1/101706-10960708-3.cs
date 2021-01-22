    public List<string> ListofNewsTitle()
            {
                var query = from n in db.NewsEvents
                            orderby n.NewsDate descending
                            select n.NewsTitle;
                return query.ToList();        
            }
