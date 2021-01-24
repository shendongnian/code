    async Task<IActionResult> DownloadFileAsync(string fileName){
        using(var net = new System.Net.WebClient()) {
            byte[] data = await net.DownloadDataTaskAsync(fileName);
            return new FileContentResult(data, "application/pdf") {
                FileDownloadName = "file_name_here.pdf"
            };
        }
    }
