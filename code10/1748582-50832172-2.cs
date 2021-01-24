    public ActionResult RMAHistory()
    {
        return View(RMAHistorik("", 0, 10, true, 0));
    }
    
    [HttpGet]
    public JsonResult RMAHistorik(string LikeOrderNummer, int From, int Amount, bool SearchRMA, int skip)
    {
        var query = GetData(LikeOrderNummer, Amount, skip).ToList();
    
        return Json(query,JsonRequestBehavior.AllowGet);
    }
    
    public string JsonRMAHistory(string LikeOrderNummer, int From, int Amount, bool SearchRMA, bool Searching, int skip)
    {
        if (Searching)
        {
            skip = 0;
        }
    
        string EmailID = Session["Email"].ToString();
        return Newtonsoft.Json.JsonConvert.SerializeObject(GetData(LikeOrderNummer, Amount, skip).Select(t => new
        {
            RMASendDato = t.RMASendDato.ToString("dd/MM/yyy"),
            OrdreDato = t.OrdreDato.ToString("dd/MM/yyy"),
            Varenummer = t.Varenummer,
            Referencenummer = t.Referencenummer,
            AntalRMA = t.AntalRMA,
            Fakturnummer = t.Fakturnummer,
            Ordrenummer = t.Ordrenummer,
            Status = t.Status,
            Email = EmailID
    
        }).Where(l => l.Email == EmailID).Distinct());
    }
    
    private static IEnumerable<RMAHistory> GetData(string LikeOrderNummer, int Amount, int skip)
    {
    	RMAHistory rma = new RMAHistory();
        string EmailID = Convert.ToString(HttpContext.Current.Session["Email"]);
    
        return db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y }).Where(a => a.y.Email == EmailID && LikeOrderNummer == "" ? true : a.y.Ordrenummer.StartsWith(LikeOrderNummer.Trim()) || a.y.Fakturnummer.StartsWith(LikeOrderNummer.Trim())).Distinct().Select(t => new RMAHistory
        {
            Status = t.u.Status,
            RMASendDato = t.y.RMASendDato,
    
        }).OrderByDescending(t => t.OrdreDato).Skip(skip).Take(Amount).ToList();
    }
