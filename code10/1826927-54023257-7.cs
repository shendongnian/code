    public class CustomerController : Controller
    {
        private static List<Customer> list;
        [HttpGet]
        public IActionResult Index()
        {
            if (list == null)
            {
                list = Enumerable.Range(1, 5).Select(x => new Customer()
                {
                    Id = x,
                    FirstName = $"A{x}",
                    LastName = $"B{x}",
                    Email = $"A{x}@B{x}.com"
                }).ToList();
            }
            var model = list.Select(x => new Trackable<Customer>(x)).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(List<Trackable<Customer>> model)
        {
            //Cleanup model errors for deleted rows
            var deletedIndexes = model.
                Where(x => x.Deleted).Select(x => $"[{x.Index}]");
            var modelStateDeletedKeys = ModelState.Keys.
                Where(x => deletedIndexes.Any(d => x.StartsWith(d)));
            modelStateDeletedKeys.ToList().ForEach(x => ModelState.Remove(x));
            //Removing rows which are added and deleted
            model.RemoveAll(x => x.Deleted && x.Added);
            //If model state is not valid, return view
            if (!ModelState.IsValid)
                return View(model);
            //Deleted rows
            model.Where(x => x.Deleted && !x.Added).ToList().ForEach(x =>
            {
                var i = list.FindIndex(c => c.Id == x.Model.Id);
                if (i >= 0)
                    list.RemoveAt(i);
            });
            //Added rows
            model.Where(x => !x.Deleted && x.Added).ToList().ForEach(x =>
            {
                list.Add(x.Model);
            });
            //Edited rows
            model.Where(x => !x.Deleted && !x.Added).ToList().ForEach(x =>
            {
                var i = list.FindIndex(c => c.Id == x.Model.Id);
                if (i >= 0)
                    list[i] = x.Model;
            });
            //Reditect to action index
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Trackable<Customer>(new Customer()) { Added = true };
            return PartialView("RowTemplate", model);
        }
    }
