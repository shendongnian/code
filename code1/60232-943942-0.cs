        protected override WebResponse GetWebResponse(System.Net.WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            response.Headers[HttpResponseHeader.ContentType] = "text/xml";
            return response;
        }
