	public class UserController : ApiController
	{
		/// <summary>
		/// Get all Persons
		/// </summary>
		/// <returns></returns>		
		[HttpGet]
        // GET: api/User/GetAll
        [Route("api/User/GetAll")]
		public IHttpActionResult GetData()
		{
			return Ok(PersonDataAccess.Data);
		}
		/// <summary>
		/// Get Person By ID
		/// </summary>
		/// <param name="id">Person id </param>
		/// <returns></returns>
        // GET: api/User/GetByID/5
        [Route("api/User/GetByID/{id}")]
		public IHttpActionResult GetById(int id)
		{
			Person person = PersonDataAccess.Data.FirstOrDefault(p => p.Id = id);
			if (person != null)
			{
				return Ok(person);
			}
			else
			{
				return NotFound();
			}
		}
	}
