    public async Task<IActionResult> GetSomeFileAsync(RequestParameters p) {
        string filePath = Preprocess(p);
        byte[] data;
        using (var fs = System.IO.File.OpenRead(filePath)) {
            data = new byte[fs.Length];
            await fs.ReadAsync(data, 0, data.Length);
        }
        return PostProcess(data);
    }
