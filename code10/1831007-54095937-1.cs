    [RoutePrefix("api/PaymentManagementController")]
    public class PaymentManagementController : ApiController
    {
        [HttpGet]
        [Route("CheckStatus/{commandType}/{account}/{txnId}")]
        public HttpResponseMessage CheckStatus(string commandType, string account, string txnId)
        {
        }
    }
