         public IHttpActionResult Get()
         {
          if(error)
              BadRequest("Bad Request !!");
           return Ok("Ciao Mondo!");
         }
