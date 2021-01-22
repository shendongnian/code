    int cnt=0;
    bool cont = true;
    while (cont)
    {
         try
         {
             MDO = OperationsWebService.MessageDownload(MI);
             cont = false; 
         }
         catch (Exception ex) 
         { 
             ++cnt;
             if (cnt == 5)
             {
                 // 5 retries, ok now log and deal with the error. 
                cont = false;
             }
         } 
    }
