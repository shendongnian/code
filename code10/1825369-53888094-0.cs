    [Route("api/[controller]"), ApiController, Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        [HttpPatch("{propertyId}/{listId}/{isOn}"), Authorize]
        public ActionResult<bool> Update(int propertyId, int listId, bool isOn)
