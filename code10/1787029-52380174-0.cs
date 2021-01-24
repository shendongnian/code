    public class StudentService : IStudentService
    {
    	private readonly IHttpContextAccessor _httpContextAccessor;
     
    	public StudentService(IHttpContextAccessor httpContextAccessor)
    	{
    		_httpContextAccessor = httpContextAccessor;
    	}
     
    public async Task<List<Student>> GetAllStudents()
        {
            var requestedUserId= _httpContextAccessor.HttpContext.Headers["Authorization"];
            LogOperation(requestedUserId);
            return context.Students.ToList();
        }
    }
