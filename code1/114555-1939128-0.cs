       RequestResult result = null;
        Action<sessionTyep> RunSession = (session =>{  
             result = session.ProcessRequest("~/Services/GetToken");
       }
       );
       RunSession(SessionVar);
       var res = result;
