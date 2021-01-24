    public class Organisations
    {
        public List<SelectListItem> agrBall { get; set; }
        public SelectListItem SelectedAgrBall { get; set; }
    }
    [HttpPost]
    public ActionResult Main(string Years, string Periods, Organisations m)
    {
        string s = m.SelectedAgrBall.Value;
        int ss = int.Parse(s);
        string t = Years;
        string b = Periods;
        return View(m);
    } 
