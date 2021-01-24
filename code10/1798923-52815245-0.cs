    public HttpResponseMessage CreateNewCase(int id)
    {
     try
     {
        Case caseResponse = new Case();
        //some process about checking if the ID exists and loading other data
        if(idCount > 0)
        {
           return Request.CreateResponse( HttpStatusCode.Conflict, caseResponse );
        }
        else
        {
         return Request.CreateResponse( HttpStatusCode.OK, caseResponse );
        } 
     }
     catch (Exception ex)
     {
        return Request.CreateResponse( HttpStatusCode.InternalServerError, null);
     }
    }
