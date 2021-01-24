    // POST: api/site
    public HttpResponseMessage Postsite(site site)
    {
           if(!db.site.Any(s => s.Name == site.name))
           {
               db.site.Add(site);
               db.SaveChanges();
               var message = Request.CreateResponse(HttpStatusCode.Created, site);
               message.Headers.Location = new Uri(Request.RequestUri + site.Id.ToString());
               return message;
           }
           else
           {
              return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
           }
        
    }
