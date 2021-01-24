        byte[] byteArray = (byte[])(Session["ByteArray"]);
        if (byteArray != null)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(byteArray, 0, byteArray.Length);
                    using (WordprocessingDocument wDoc = WordprocessingDocument.Open(ms, true))
