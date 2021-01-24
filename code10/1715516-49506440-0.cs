    using Ionic.Zip;
    using System.IO;
    using System.Net;
    [HttpPost]
    public ActionResult Downloads(string lang, string product, IEnumerable<string> file, string action)
    {
        string zipname = "manuals.zip";
        List<MemoryStream> streams = new List<MemoryStream>();
        using (ZipFile zip = new ZipFile())
        {
            foreach (string f in file.Distinct())
            {
                using (WebClient client = new WebClient())
                {
                    MemoryStream output = new MemoryStream();
                    byte[] b = client.DownloadData(f);
                    output.Write(b, 0, b.Length);
                    output.Flush();
                    output.Position = 0;
                    zip.AddEntry(f.Split('/').Last(), output);
                    // output.Close(); // ← removed this line
                    streams.Add(output);
                }
            }
            Response.Clear();
            Response.ContentType = "application/zip, application/octet-stream";
            Response.AddHeader("content-disposition", $"attachment; filename={product.Replace('/', '-')}-{zipname}");
            zip.Save(Response.OutputStream);
            foreach (MemoryStream stream in streams)
            {
                stream.Close();
                stream.Dispose();
            }
            Response.End();
        }
    }
