    // POST: api/ReqsTests
        public async Task<IHttpActionResult> PostReqsTest(object json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //convert the Json model to xml
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json.ToString());
            try
            {
                //SQL store procedure
                SqlParameter param1 = new SqlParameter("@XmlIn", doc.InnerXml);
               db.Database.ExecuteSqlCommand("exec [CHC_Web].[TestWebHandShake] @XmlIn",
                                              param1);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message));
            }
           return ResponseMessage(Request.CreateResponse HttpStatusCode.OK,"Inserted to database"));        }
