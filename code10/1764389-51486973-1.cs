    public ActionResult Archives(int i = 0)
    {
        var recordLists = new List<RecordList>();
          if(i == 0)
              recordLists = _db.recordlists.Where(p => p.date.Value.Year == DateTime.Now.Year)
                              .OrderByDescending(p => p.date).ToList();
          else{
              recordLists = _db.recordlists.Where(p => p.date.Value.Year == i).OrderByDescending(p => p.date).ToList();
          }
          return View(new Model{Records = recordLists, Year = i});
    }
