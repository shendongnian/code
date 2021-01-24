    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    
    class MainClass {
      public static void Main (string[] args) {
        var url = new Uri("https://v2.convertapi.com/html/to/pdf?download=attachment&secret=<YourSecret>");
        var htmlString = "<!doctype html><html lang=en><head><meta charset=utf-8><title>ConvertAPI test</title></head><body>This page is generated from HTML string.</body></html>";
        var content = new StringContent(htmlString, Encoding.UTF8, "application/octet-stream");
        content.Headers.Add("Content-Disposition", "attachment; filename=\"data.html\"");
        using (var resultFile = File.OpenWrite(@"C:\Path\to\result\file.pdf"))
        {
            new HttpClient().PostAsync(url, content).Result.Content.CopyToAsync(resultFile).Wait();
        }
      }
    }
