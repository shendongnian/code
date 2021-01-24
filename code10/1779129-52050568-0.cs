    public static class UserResolverService
    {
        public static Guid GetUserId(this ControllerBase controller)
        {
            var result = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(result);
        }
    }
