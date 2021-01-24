      IPagedList<RMAHistory> query = db.RMAStatus
       .Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y })
       .Where(x => x.y.Kundenavn.Contains(searchingLukkedesager) || x.y.Id.ToString().Contains(searchingLukkedesager))
       .Select(t => new RMAHistory
            {
               Kundenavn = t.y.Kundenavn,
               Id = t.y.Id
            }).ToPagedList(pageNumber ?? 1, 10);
            return View(query);
