    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Produces("application/json")]
        [HttpPost]
        public void PostStudent(Student students)
        {
              // you can get data here from students objects
        }
    }
