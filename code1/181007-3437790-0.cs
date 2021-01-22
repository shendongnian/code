        private void TransmitBytes(byte[] bytes, string outFileName)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + outFileName);
            Response.AddHeader("Content-Length", bytes.Length.ToString());
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(bytes);
            Response.End();
        }
