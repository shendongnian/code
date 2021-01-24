    public class RoleUtility 
    {
        private readonly RoleManager<IdentityRole> _roleManager;
    
        public RoleUtility(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
    
        public void PopulateRolesList(RegisterViewModel model)
        {
            model.Roles = _roleManager.Roles?.ToList();
        }
    }
