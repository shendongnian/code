    protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpRequest request = HttpContext.Current.Request;
            HttpResponse response = HttpContext.Current.Response;
            if ((request.HttpMethod == "POST") &&
                (response.StatusCode == 404 && response.SubStatusCode == 13))
            {
                // Clear the response header but do not clear errors and
                // transfer back to requesting page to handle error
                response.ClearHeaders();
                HttpContext.Current.Server.Transfer(request.AppRelativeCurrentExecutionFilePath);
            }
        }
