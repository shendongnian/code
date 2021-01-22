     Byte[] bytes = (Byte[])dr["Data"];
     Response.Buffer = true;
     Response.Charset = "";
     Response.Cache.SetCacheability(HttpCacheability.NoCache);
     Response.ContentType = dr["Image/JPEG"].ToString();
     Response.AddHeader("content-disposition", "attachment;filename=" & dt.Rows[0]["Name"].ToString());
     Response.BinaryWrite(bytes);
     Response.Flush();
     Response.End(); 
