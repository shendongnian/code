    public ActionResult RMAHistory()
    {
        return View(getRMAHistory("", 0, 10, 0));
    }
    
    [HttpGet]
    public JsonResult RMAHistorik(string LikeOrderNummer, int From, int Amount, int skip)
    {
       List<RMAHistory> results = getRMAHistory(LikeOrderNummer, From, Amount, skip);
       return Json(results, JsonRequestBehavior.AllowGet);
    }
    //private method to allow RMAHistory query to be re-used in both action methods
    private List<RMAHistory> getRMAHistory(string LikeOrderNummer, int From, int Amount, int skip)
    {
        string EmailID = Session["Email"].ToString();
        List<RMAHistory> query = db.RMAStatus
          .Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y })
          .Where(a => a.y.Email == EmailID && LikeOrderNummer == "" ? true : a.y.Ordrenummer.StartsWith(LikeOrderNummer.Trim()) || a.y.Fakturnummer.StartsWith(LikeOrderNummer.Trim()))
          .Distinct()
          .Select(t => new RMAHistory
          {
              Status = t.u.Status,
              RMASendDato = t.y.RMASendDato,
          })
          .OrderByDescending(t => t.OrdreDato)
          .Skip(skip)
          .Take(Amount)
          .ToList();
    
        return query;
    }
