    public class CustomController : Controller
    {
        protected virtual async Task<TModel> CreateModel<TModel>() where TModel : PartialLoginViewModel, new()
        {
            TModel model = new TModel();
            var userName = User.Identity.Name;
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.UserName == userName);
            // Set common properties
            model.Nome = applicationUser.Nome;
            return model;
        }
    }
