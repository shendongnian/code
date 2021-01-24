    [HttpGet]
    [Route("/progress/data.csv")]
    [Produces("text/csv")]
    public IActionResult MyFileDownload()
    // public Utf8ForExcelCsvResult MyFileDownload()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("æø;2;3;");
        sb.AppendLine("გამარჯობა");
        sb.AppendLine("ဟယ်လို");
        sb.AppendLine("ສະບາຍດີ");
        sb.AppendLine("cześć");
        sb.AppendLine("こんにちは");
        sb.AppendLine("你好");
        Console.WriteLine(sb.ToString());
        return new Utf8ForExcelCsvResult(){
            Content=sb.ToString(),
            ContentType="text/csv",
            FileName="hello.csv",
        };
    }
