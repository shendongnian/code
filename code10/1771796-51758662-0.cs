    public static HttpResponseMessage loadjoueurs(int id)
        {
                HttpResponseMessage Res = client.GetAsync("joueurs?id=" + id);
    return Request.CreateResponse(HttpStatusCode.OK,EmpInfo, "application/json");
         }
