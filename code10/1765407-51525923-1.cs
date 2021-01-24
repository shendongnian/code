    //namespace Testy20161006.Controllers
    public class FlavorViewModel
    {
        public List<SelectListItem> FlavorDDL { get; set; }
        public string SelectedFlavor { get; set; }
        public bzFlav Flavor { get; set; }
        public FlavorViewModel()
        {
            this.FlavorDDL = new List<SelectListItem>();
            SelectListItem f1 = new SelectListItem();
            f1.Selected = true;
            f1.Text = "FlavorA";
            f1.Value = "FlavorA";
            SelectListItem f2 = new SelectListItem();
            f2.Text = "FlavorB";
            f2.Value = "FlavorB";
            this.FlavorDDL.Add(f1);
            this.FlavorDDL.Add(f2);
        }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Tut117(FlavorViewModel fvm)
        {
            using (user7221204 db = new user7221204())
            {
                bzFlav flav = new bzFlav
                {
                    Address = fvm.Flavor.Address,
                    Email = fvm.Flavor.Email,
                    Flavor = fvm.Flavor.Flavor,
                    Name = fvm.Flavor.Name,
                    Phone = fvm.Flavor.Phone,
                    Serial = fvm.Flavor.Serial
                };
                db.bzFlavs.Add(flav);
                db.SaveChanges();
            }
            return View(fvm);
        }
        public ActionResult Tut117()
        {
            FlavorViewModel fvm = new FlavorViewModel();
            return View(fvm);
        }
