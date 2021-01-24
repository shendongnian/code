        namespace DapperPro.Controllers
        {
            public class LockoutOptionsController : Controller
            {
                private readonly ApplicationDbContext _context;
                private readonly IdentityOptions _identityOptions;
                private readonly ISecuritySettingService _securitySettingService;
                public LockoutOptionsController(ApplicationDbContext context
                    , IOptions<IdentityOptions> identityOptions
                    , ISecuritySettingService securitySettingService)
                {
                    _context = context;
                    _identityOptions = identityOptions.Value;
                    _securitySettingService = securitySettingService;
                }        
                // POST: LockoutOptions/Edit/5
                // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
                // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("Id,AllowedForNewUsers,MaxFailedAccessAttempts,DefaultLockoutTimeSpan")] LockoutOption lockoutOption)
                {
                    _securitySettingService.UpdateSecuritySetting(lockoutOption);
                
                    return View(lockoutOption);
                }        
            }
        }
