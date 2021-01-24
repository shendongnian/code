    namespace Vaktliste.Controllers
    {
        public class BranchesController : MyBaseControllerClass
        {
            private readonly VaktlisteContext db;
    
            public BranchesController(VaktlisteContext context)
            {
                db = context;
            }
    
            public async Task<IActionResult> Details(int? id)
            {
                // USE THE VARIABLE HERE:
                id = id ?? BranchId;
    
                if (id == null) return NotFound();
    
                var branch = await db.Branches
                    .Where(m => m.Id == id)
                    .FirstOrDefaultAsync();
    
                if (branch == null) return NotFound();
    
                BranchId = branch.Id;
    
                return View(branch);
            }
        }
    }
