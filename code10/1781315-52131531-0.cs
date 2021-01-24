    Task<IActionResult> DownloadFileAsync(string fileName);
        return Task.Run(() => {
            var net = new System.Net.WebClient();
            byte[] data = net.DownloadData(fileName);
            return new FileContentResult(data, "application/pdf") {
                FileDownloadName = "file_name_here.pdf"
            };
        });
    }
