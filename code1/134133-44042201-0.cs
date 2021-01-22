    string outFile = System.IO.Path.Combine(outDir, fileName);
    // Download file
    var request = (HttpWebRequest) WebRequest.Create(imageUrl);
    using (var response = await request.GetResponseAsync()){
        using (var reader = new BinaryReader(response.GetResponseStream())) {
            // Read file 
            Byte[] bytes = async reader.ReadAllBytes();
            // Write to local folder 
            using (var fs = new FileStream(outFile, FileMode.Create)) {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
