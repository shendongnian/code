	[RoutePrefix("api/v1/user")]
	public class UserController : ApiController
	{
		/// <summary>
		/// Get all Persons
		/// </summary>
		/// <returns></returns>		
		[HttpGet]
		public IHttpActionResult GetData()
		{
			return Ok(PersonDataAccess.Data);
		}
		/// <summary>
		/// Get Person By ID
		/// </summary>
		/// <param name="id">Person id </param>
		/// <returns></returns>
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
