    [Route("panel/admin")]
    public class MyController {
    
        [HttpGet]
        [Route("")] //GET panel/admin
        [Route("[action]")]  //GET panel/admin/index
        public IActionResult Index() {
            return View();
        }
    
        [HttpGet]
        [Route("[action]")] //GET panel/admin/UsersList
        public IActionResult UsersList() {
            var users = _db.Users.ToList();
            return View(users);
        }
    
        // Other actions like UsersList
    }
