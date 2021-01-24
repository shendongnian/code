        [HttpPost]
        public HttpResponseMessage Post([FromBody] string value)
        {
            int width = 0;
            Int32.TryParse(value, out width);
            string devicevalue = null;
            if (width < 768)
            {
                devicevalue = "mobile";
            }
            else
            {
                devicevalue = "non-mobile";
            }
            var cookie = new CookieHeaderValue("device-type", devicevalue);
            cookie.Expires = DateTime.Now.AddMinutes(30);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
        }
