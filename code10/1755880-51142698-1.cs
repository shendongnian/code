    [Route("panel/admin/[action]")]
    public class MyController {
    
        [HttpGet] //GET panel/admin/index
        [Route("~/panel/admin")] //GET panel/admin        
        public IActionResult Index() {
            return View();
        }
    
        [HttpGet] //GET panel/admin/UsersList
        public IActionResult UsersList() {
            var users = _db.Users.ToList();
            return View(users);
        }
    
        // Other actions like UsersList
    }
