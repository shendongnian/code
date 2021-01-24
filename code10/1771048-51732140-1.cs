    [Route("api/[controller]")]
    //  [ApiController] // works either way
    public class UController : ControllerBase
    {
        [HttpPost]
        public async Task<string> signUp()
        {
            String body;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
            }
    
            UserSignup user = JsonConvert.DeserializeObject<UserSignup>(body);
    
            return user.email;
        }
    }
