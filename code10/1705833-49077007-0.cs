    public class XmlEampleController : ApiController
    {
        [HttpPost]
        [ActionName("MyOrderAction")]
        public HttpResponseMessage MyOrder([FromBody]MyOder order)
        {
            if (order != null)
            {
                return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    [Serializable]
    public partial class MyOder
    {
        private string dataField;
        public string MyData
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }
    }
