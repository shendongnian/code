    [Route( "v1/[controller]" )]
    public class ButtonsController : Controller
    {
      ...
      [HttpPost]
      public IActionResult PostButtonClick( string buttonId ) {
        // buttonId now has a value !!!
      }
    } 
