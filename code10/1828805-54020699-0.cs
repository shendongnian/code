    namespace SchedulingSystem.Controllers
        {
            [RoutePrefix("api/Sections")]
                public class SectionsController : Controller
                {
                   [HttpPost]
                   [Route("assign/{sectionId}")]
                   public async Task<IActionResult> AssignRoom(int sectionId, [FromBody] SaveRoomSectionAssignmentResource resource)
                   {
                      // some code here
                   }
                }
            }
