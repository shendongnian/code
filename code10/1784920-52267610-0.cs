    public class TimeAllocationController : BaseApiController
    {
        [Route("api/timeallocation")]
        [HttpPost]
        public async Task<ActivityValidationResult> Post(JObject json)
        {
            string id = json["id"];
            //login here
        }
    }
    
    or
    
    public class TimeAllocationController : BaseApiController
    {
        [Route("api/timeallocation")]
        [HttpPost]
        public async Task<ActivityValidationResult> Post(dynamic json)
        {
            string id = json.id ?? "";
            //login here
        }
    }
    $.ajax({
        url: "/api/timeallocation/",
        dataType: "json",
        type: "POST",
        data: {
            id: categoryId
        }
    });
