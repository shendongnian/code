                        HttpResponse Response = context.Response;
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.ContentType = "application/xls";
                        Response.Charset = "UTF-8";
                        Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                        Response.AddHeader("content-disposition", "attachment; filename=text.xml" ) ;
