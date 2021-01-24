    public async Task<IActionResult> DownloadDocument(string path)
    {
       byte[] berichtData = null;
       FileInfo fileInfo = new FileInfo(path);
       long berichtFileLength = fileInfo.Length;
       FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
       BinaryReader br = new BinaryReader(fs);
       berichtData = br.ReadBytes((int)berichtFileLength);
       return File(berichtData, MimeTypeHelper.GetMimeType("pdf"));
    }
