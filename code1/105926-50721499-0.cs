      [Route("api/testWebService")]
      [AllowAnonymous]
      [HttpGet]
      public HttpResponseMessage TestWebService()
      {
          HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
          string loc = Assembly.GetAssembly(typeof(@Class@)).Location;
          FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(loc);
          responseMessage.Content = new StringContent($"<h2>The XXXXX web service GET test succeeded.</h2>{DateTime.Now}<br/><br/>File Version: {versionInfo.FileVersion}");
          responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
          Request.RegisterForDispose(responseMessage);
          return responseMessage;
      }
