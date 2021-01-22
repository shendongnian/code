string path = @"D:\New people metrix 7th april\People Metrix New Web\Bin\Inbox.mdb";
FileInfo fileinfo = new FileInfo(path);
HttpContext.Current.Response.Clear();
HttpContext.Current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", path));
HttpContext.Current.Response.ContentType = "application/octet-stream";
HttpContext.Current.Response.BinaryWrite(File.ReadAllBytes(fileinfo,.FullName));
HttpContext.Current.Response.Flush();
HttpContext.Current.Response.End();
