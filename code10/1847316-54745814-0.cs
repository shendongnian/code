cs
public class ControllerBase : Controller
{
    public string UserId
    {
        get
        {
            if (User != null) /* The user object is found to be null here. */
            {
                var userIdNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdNameClaim != null)
                {
                    return userIdNameClaim.Value;
                }
            }
            return null;
        }
    }
}
And your specific controller:
cs
public class WorldController : ControllerBase
{
    // Contructor, etc...
    public IActionResult Get()
    {
       var userId = UserId;
       // Do something with userId (or use UserId directly)
    }
}
