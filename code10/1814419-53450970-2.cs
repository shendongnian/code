    public static string GetUserRole(this ApiController controller) {
        var request = controller.Request;
        var user = controller.User
        return request.GetOwinContext()
            .GetUserManager<ApplicationRoleManager>()
            .FindById(user.Identity.GetUserId()).Name;     
    }
