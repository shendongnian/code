    public Exception HandleException(Exception ex, Guid handlingInstanceID) {
        HttpResponse response = HttpContext.Current.Response;
        HttpSessionState session = HttpContext.Current.Session;
        session["ErrorPageText"] = BuildErrorPage(ex, handlingInstanceID);
        response.Redirect(errorPageUrl, false);
        return ex;
    }
