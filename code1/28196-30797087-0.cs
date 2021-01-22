     [HttpGet]
        public async Task<ActionResult> Index(int page =1)
        {
            if (page < 0 || page ==0 )
            {
                page = 1;
            }
            int pageSize = 5;
            int totalPage = 0;
            int totalRecord = 0;
            BusinessLayer bll = new BusinessLayer();
            MatchModel matchmodel = new MatchModel();
            matchmodel.GetMatchList = bll.GetMatchCore(page, pageSize, out totalRecord, out totalPage);
            ViewBag.dbCount = totalPage;
            return View(matchmodel);
        }
