    [Route("api/rates")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatesController : Controller
    {
    }
