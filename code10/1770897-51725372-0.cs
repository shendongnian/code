     public IEnumerable<Tender> GetTenders(string userId)
        {
            var user = _context.Users.Where(u => u.Id == userId);
    
            return _context.Tenders
                           .Include("TenderCircles.Circle.Members")
                           .Where(t => t.Visibility == TenderVisibility.Public ||
                                 (t.Visibility == TenderVisibility.Circles && t.TenderCircles.Any(tc => tc.Circle.Members.Any(m=>m.Id == userId)))
                           .ToList();
        }
