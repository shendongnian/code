        [HttpGet("[action]")]
        public void GetRawString()
        {
            string csv = "a,c,d";
            Response.ContentType = "text/plain; charset=UTF-8";
            Response.Body.Write(Encoding.UTF8.GetBytes(csv));
        }
