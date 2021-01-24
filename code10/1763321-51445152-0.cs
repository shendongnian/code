    public static HttpResponseMessage CallApi(string token, Func<T> method) {
        HttpResponseMessage response = ServicesAPIAuth.CheckToken(token);
        if (response.StatusCode == HttpStatusCode.OK) {
            //call the method passed here
            response = ServicesJsonWebApi.FormatJsonApiResponse(method(), HttpStatusCode.OK);
        }
        return response;
    }
