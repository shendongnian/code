    public ActionResult Pathway(int? id,int? index)
    {
        int currentIndex = index.GetValueOrDefault();
        if (currentIndex == 0)
        {
            ViewBag.NextIndex = 1;
        }
        else
        {
            ViewBag.NextIndex = index + 1;
        }
        ........
        
        PathwayViewModel path = new PathwayViewModel();
        var stageQuestion = _context.StageQuestion.Where(x => x.IncidentTypeId == incident.IncidentTypeId)
        .Include(s => s.Stage)
        .Include(o => o.Stage.Outcome).OrderBy(x=>x.Id).Skip(currentIndex).Take(1).FirstOrDefault();
        path.StageQuestion = stageQuestion;
        
        
        return View(path);
    }
