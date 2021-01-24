     public ActionResult RMAList(string searchingrma, int? pageNumber) 
            {
        
                var query = db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y }).
                Where(x => x.y.Ordrenummer.Contains(searchingrma) && x.y.Fakturnummer.Contains(searchingrma) || searchingrma == null).
                Select(t => new RMAHistory
                {
        
                    OrdreDato = t.y.OrdreDato,
                    AntalRMA = t.y.AntalRMA
        
        
                }).OrderBy(t => t.OrdreDato).ToPagedList(pageNumber ?? 1, 5);
        
        
                return View(query);
            }
