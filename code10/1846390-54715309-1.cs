    public class RoleViewModel
    {
       public string RoleId { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public List<UserViewModel> Users { get; set; }
    }
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
    public ViewResult Index()
    {
        List<RoleViewModel> rolesWithUsers = new List<RoleViewModel>();
        List<ApplicationRole> applicationRoles = RoleManager.Roles.Include(r => r.Users).ToList();
        foreach (ApplicationRole applicationRole in applicationRoles)
        {
            RoleViewModel roleViewModel = new RoleViewModel()
            {
                    RoleId = applicationRole.Id,
                    Name = applicationRole.Name,
                    Description = applicationRole.Description
            };
            List<UserViewModel> usersByRole = UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == applicationRole.Id))
                    .Select(u => new UserViewModel
                    {
                        UserId = u.Id,
                        UserName = u.UserName
                    }).ToList();
            roleViewModel.Users = usersByRole;
            rolesWithUser.Add(roleViewModel);
        }
    
        return View(rolesWithUsers);
    }
