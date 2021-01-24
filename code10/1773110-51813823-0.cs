        namespace SelfApi.Controllers
     {
       public class ValuesController : ApiController
        {
          private AppDataBaseContext DB = new AppDataBaseContext();
       // POST api/values
       public async Task PostAsync([FromBody] Student student)
        {
          DB.Student.Add(student);
          await DB.SaveChangesAsync();
    return Ok();
       }
      } 
    }
