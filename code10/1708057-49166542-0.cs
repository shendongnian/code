    Response.ContentType = "Application/pdf";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                            Response.TransmitFile(filename);
                            Response.Flush();
                            Response.End();
                            Response.Write("<script>setTimeout(function(){ window.close; }, 1000);");  
                            //return Redirect("/Home/Index");
                            System.Windows.Forms.Application.ExitThread();
