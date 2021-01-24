    public async Task<IActionResult> UploadCsvFiles(ICollection<IFormFile> files, IFormCollection fc)
    {
       foreach (var f in files)
       {
           var getData = new GetLogTagData(_configuration);
           await getData.SplitCsvData(f, uid);
       }
       return whatever;
    }
