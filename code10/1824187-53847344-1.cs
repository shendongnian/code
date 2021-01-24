    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public void PostStudent([FromQuery]List<Student> students)
        {
        }
    }
