        public ActionResult Download()
        {
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentType = "text/html";
            Response.AddHeader("Content-Disposition", "attachment; filename=records.html");
        
            var subString = "";
            for (var i = 0; i < 500000000; i++)
            {
                subString += "<sometag></sometag>";
                if (subString.Length > 100)
                {
                    var byteArray = Encoding.ASCII.GetBytes(subString);
                    var stream = new MemoryStream(byteArray);
                    Response.BinaryWrite(stream.ToArray());
                    stream.Flush();
                    stream.Close();
                    stream.Dispose();
                    subString = string.Empty;
                }
            }
            Response.Flush();
            Response.Close();
            Response.End();
            return null;
        }
