    public IActionResult GetSomeFile(RequestParameters p) {
        string filePath = Preprocess(p);
        var data = System.IO.File.ReadAllBytes(filePath);
        return PostProcess(data);
    }
