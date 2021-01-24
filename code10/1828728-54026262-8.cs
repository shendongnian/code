    static void connvert()
    {
        var lines =
            File.
            ReadAllLines
            (@"C:\temp\Laura.txt",
                Encoding.GetEncoding("Windows-1255")
            );
    
        var csv = lines.Select(x =>
        {
            var parts = x.Split('\t');
            return new Articles()
            {
                id = parts[0].Trim(),
                name = parts[1].Trim(),
                body = parts[2].Trim(),
            };
        }).ToList();
    
    
    
        foreach (var item in csv)
        {
            string id = item.name;
            string filename = item.name + ".html";
            string body = item.body;
            string path = @"c:\temp\" + filename;
    
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                //  File.WriteAllText(path, body);
                File.WriteAllText(path, body, Encoding.Unicode); // try this
                //   File.WriteAllText(path, body, Encoding.Encoding.GetEncoding("Windows-1255"));// then this
    
                var app = new Application();
                var doc = app.Documents.Open(path, false);
                var OutputFileName =
                    Path.Combine(
                        Path.GetDirectoryName(path),
                        Path.GetFileNameWithoutExtension(path) +
                        ".pdf");
                doc.ExportAsFixedFormat
                    (OutputFileName,
                        WdExportFormat.wdExportFormatPDF
                    );
            }
        }
    }
