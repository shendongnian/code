            Response.ContentType = "application/pdf";
            byte[] bytes = YourBinaryContent;
         
            using (BinaryWriter writer = new BinaryWriter(context.Response.OutputStream))
            {
                writer.Write(bytes, 0, bytes.Length);
            }
