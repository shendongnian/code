                if (Request.RequestType.ToUpper() == "POST")
                {
                    using (StreamReader rd = new StreamReader(Request.InputStream))
                    {
                       string response = string.Empty;
                       try
                       {
                          Process(rd.ReadToEnd());
                          response = GetFDF(true);
                       }
                       catch (Exception)
                       {
                          response = GetFDF(false);
                       }
                       Response.ContentType = "application/vnd.fdf";
                       Response.Output.Write(response);
                       Response.End();
                    }
                }
