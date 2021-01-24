    public class SomeController : Controller
    {
        private readonly ClaimCookie _claimCookie;
     
        public SomeController(ClaimCookie claimCookie)
        {
            _claimCookie = claimCookie;
        }
    
        public async Task<IActionResult> SomeAction()
        {
            int id = int.Parse(_claimCookie.GetValue(CookieName.User, KeyName.Id));
            await _claimCookie.SetValue(CookieName.User, new[] { KeyName.Name, KeyName.Surname }, new[] { model.Name, model.Surname });
            ...
        }
