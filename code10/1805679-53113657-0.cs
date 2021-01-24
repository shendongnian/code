            blobfile.FetchAttributes();
            using (StreamReader blobfilestream = new StreamReader(blobfile.OpenRead()))
            {
                dataBytes1 = blobfilestream.CurrentEncoding.GetBytes(blobfilestream.ReadToEnd());
                await blobfile.DownloadToStreamAsync(Response.OutputStream);
            }
            Byte[] value = BitConverter.GetBytes(dataBytes1.Length - 1);
            string mimeType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename="+ filename);
            return File(value, mimeType);
