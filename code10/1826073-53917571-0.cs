    public class RequestController: ApiController {
        private static HttpClient apiClient = new HttpClient();
    
        [HttpPost]
        public async Task<IHttpActionResult> GetWebApiData([FromBody] ParamData data) {
            var response = await apiClient.GetAsync(apiUrl);
            var resultContent = response.Content;
            var model = await resultContent.ReadAsAsync<dynamic>();
            return Ok(model);
        }
    }
