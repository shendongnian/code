    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    
    namespace MyApp.Controllers
    {
    
        public class RolesController : Controller
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<IdentityUser> _userManager; 
    
            public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }
            
            [HttpPost]
            public async Task<IActionResult> AssignRoleToUser(string _roleName, string _userName)
            {
                //Created a user
                var user = new IdentityUser { UserName = _userName, Email = "xyz@somedomain.tld" };
                var result = await _userManager.CreateAsync(user, "[SomePassword]");
                if (result.Succeeded)
                {
                    // assign an existing role to the newly created user
                    await _userManager.AddToRoleAsync(user, "Admin");
                }            
                return View();
            }
    
        }
    }
