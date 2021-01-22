      public List<Match> GetMatchCore(int page, int pageSize, out int totalRecord, out int totalPage)
        {
            SignalRDataContext db = new SignalRDataContext();
            var query = new List<Match>();
            totalRecord = db.Matches.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            query = db.Matches.OrderBy(a => a.QuestionID).Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
            return query;
        }
