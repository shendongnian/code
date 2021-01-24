    [HttpPost]
    public ActionResult ActionName(...)
    {
        byte[] bytes;
    
        // other logic here
    
        using (var ms = new MemoryStream())
        {
            TextWriter tw = new StreamWriter(ms);
            tw.WriteLine("Line 1");
            tw.WriteLine("Line 2");
            tw.WriteLine("Line 3");
            tw.Flush();
            bytes = ms.ToArray();
        }
    
        TempData["bytes"] = bytes; // add this line
    
        return Json(new { fileName = "YourFileName.txt" });
    }
