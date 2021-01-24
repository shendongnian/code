        [HttpGet]
        public HttpResponseMessage GetFardosAlgodoeira(int id, string dateTime)
        {
            try
            {
                DateTime? data = null;
                if (dateTime is DateTime date)
                    data = date;
                var result = _service.GetFardosAlgodoeira(id, dateTime.ToString(new CultureInfo("yyyy-MM-dd HH:mm:ss")));
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
