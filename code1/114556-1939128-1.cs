       RequestResult result = null;
       Action<sessionTyep> Runn = (session =>{  
             result = session.ProcessRequest("~/Services/GetToken");
       }
       );
       RunSession(Runn);
       var res = result;
