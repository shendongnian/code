    public static async Task<Stream> GetDb() {
        var filepath = Path.Combine("c:/users/tom/Downloads", "productdb.zip");
        using (var archive = ZipFile.OpenRead(filepath)) {
            var entry = archive.Entries.Single(e => e.FullName == "productdb.json");
            using (var stream = entry.Open()) {
                var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return ms;
            }
        }
    }
