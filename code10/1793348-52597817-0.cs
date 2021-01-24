       [Route("sendemail")]
       [HttpPost]
       public bool SendEmail(EmailObj email)
       {
           if(email !=null)
           {
               return true;
           }
           return false;
       }
       
