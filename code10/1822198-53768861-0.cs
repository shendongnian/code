    cRequestString = ".....";//You need to set up you own URL here.  
                //Make the API call  
                try  
                {  
        byte[] bHeaderBytes = System.Text.Encoding.UTF8.GetBytes(GetUserPasswordString()); //user and pa for third party call.  
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cRequestString);  
                    request.Method = WebRequestMethods.Http.Get;  
                    request.PreAuthenticate = true;  
                    request.ContentType = "application/pdf";  
                    request.Accept = "application/pdf";  
                    request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(bHeaderBytes));  
                    MemoryStream memStream;   
                    WebResponse response = request.GetResponse();                 
                    using (Stream stream = response.GetResponseStream())                   
                    using (StreamReader reader = new StreamReader(stream))  
                    {  
                        memStream = new MemoryStream();  
                        //read small blocks to show correctly  
    					byte[] buffer = new Byte[1023];  
                        int byteCount;  
                        do  
                        {  
                            byteCount = stream.Read(buffer, 0, buffer.Length);  
                            memStream.Write(buffer, 0, byteCount);  
                        } while (byteCount > 0);  
                    }  
                    memStream.Seek(0, SeekOrigin.Begin);//set position to beginning    
                    return memStream;    
                }  
                catch  
                {  
                    return null;  
                }  
    
    //save MemoryStream to local pdf file  
     private void SavePDFFile(string cReportName, MemoryStream  pdfStream)  
            {  
                //Check file exists, delete  
                if (File.Exists(cReportName))  
                {  
                    File.Delete(cReportName);  
                }  
                using (FileStream file = new FileStream(cReportName, FileMode.Create, FileAccess.Write))  
                {  
                    byte[] bytes = new byte[pdfStream.Length];  
                    pdfStream.Read(bytes, 0, (int)pdfStream.Length);  
                    file.Write(bytes, 0, bytes.Length);  
                    pdfStream.Close();  
                }  
            }  
     
