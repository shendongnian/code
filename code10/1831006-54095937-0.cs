    [RoutePrefix("api/PaymentManagementController")]
    public class PaymentManagementController : ApiController
    {
        [HttpGet]
        [Route("CheckStatus")]
        public HttpResponseMessage CheckStatus(string commandType, string account, string txnId)
        {
        }
