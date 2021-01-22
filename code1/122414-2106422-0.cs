   Session[] oDroppedSessions;
   try
   {
      if (e.Data.GetData("Fiddler.Session[]") != null){
          object[] objs = e.Data.GetData("Fiddler.Session[]");
          if (objs != null && objs.Length &gt; 1){
             oDroppedSessions = new Session[objs.Length];
             int nIndex = 0;
             foreach(object obj in objs){
                if (obj is Session){
                  oDroppedSessions[nIndex] = (Session)obj;
                  nIndex++;
                }
             }
          }
      }
   }
   catch (Exception eX)
   {  // reaches here }
