     [HttpGet]
            public ActionResult index(int OpCode)
            {
               
                    try
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/App_Data/TempPSC/PscData/Temp_folder"));
                        foreach (FileInfo csvfile in di.GetFiles())
    
                        {
                            csvfile.Delete();
                        }
                        MyWebClient webClient1 = new MyWebClient();
                        webClient1.DownloadFile("http://example.php", Server.MapPath("~/App_Data/TempPSC/PscData/Temp_folder/Summary.csv"));
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("ImportSendMail");
    
                    }
    
                    var absolutePath = HttpContext.Server.MapPath("~/App_Data/TempPSC/PscData/Temp_folder/" + "Summary.csv");
                    if (System.IO.File.Exists(absolutePath))
                    {
                        
                        System.IO.DirectoryInfo di2 = new DirectoryInfo(Server.MapPath("~/App_Data/TempPSC/PscData"));
                        foreach (FileInfo csvfile in di2.GetFiles())
    
                        {
                            csvfile.Delete();
                        }
                      
                            String sourceFile = Server.MapPath("~/App_Data/TempPSC/PscData/Temp_folder/Summary.csv");
                            String destFile = Server.MapPath("~/App_Data/TempPSC/PscData/abc" + ".csv");
                            System.IO.File.Copy(sourceFile, destFile, true);
                    
                      
                    }
    
                  {
    			  //Rest of the default code that you want to run
    			  
    			  }
              
                return View();
              
            }
