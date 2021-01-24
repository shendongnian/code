    public class MyInformationController : ApiController
    {
        [HttpPut]
        public async Task<dynamic> Put(JObject myData)
        {
           // I need to parse data and return the new dynamic object
           // Manipulate myData according to a given logic
    
            return myData;
        }
    }
