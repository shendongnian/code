    public abstract class BaseController : Controller
    {
      public IActionResult ResponseType(Response response)
      {
        if (response.Status)
            return Ok(response);
        return BadRequest(response);
      }
    }
