    public async Task<IActionResult> UploadCsvFiles(ICollection<IFormFile> files, IFormCollection fc)
    {
       foreach (var f in files)
       {
           var getData = new GetData(_configuration);
           await getData.SplitCsvData(f, uid);
       }
       return whatever;
    }
