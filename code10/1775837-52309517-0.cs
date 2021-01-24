       public class SYMController : Controller
    {
        ISYM _ap;
        IttaessData _ad;
        public SYMController()
        {
            _ap = new LISYM();
            _ad = new LIttaessData();
        }
        public int pageSize = 15;
        public ActionResult Index(int? page, string name)
        {
            IList<ISYM> list = _ap.getDataList();
            var query = (from item in list
                         select new SYMViewModel
                         {
                             id = item.id,
                             tta_name = item.tta_name,
                             gender = item.gender,
                             unitname = item.unitname,
                             jobtitle = item.jobtitle,
                             servicestate = item.servicestate,
                             phone = item.phone,
                             enable=item.enable
                         }).ToList();
            foreach (var item in query)
            {
                item.tta_name = item.tta_name == null ? "" : item.tta_name;
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.tta_name.Contains(name)).ToList();
            }
            query = query.Where(a => a.enable==true).ToList();
            var result = query
                .OrderByDescending(x => x.tta_name)
                .ThenBy(x => x.tta_name).ToPagedList(page ?? 1, pageSize);
            var num = query.Count();
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            ViewBag.num = num;
            ViewBag.count = query.Count();
            ViewBag.name = name;
            return View(result);
        }
        public ActionResult Detail(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SYMViewModel APVM = new SYMViewModel();
            ISYM IA = _ap.getSYMId(id);
            getFile(IA.picfile, IA.id);
            IList<IttaessData> list = _ad.getDataList();
            var ttaessdata = (from AD
