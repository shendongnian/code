    [HttpGet]
    public IActionResult document(int id)
    {
          var byteArray = db.instances.Where(c => c.id == id).FirstOrDefault().document;    
          if (byteArray == null)
          {
                return null;
          }
          Stream stream = new MemoryStream(byteArray);
    
          Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
          return File(stream, "application/pdf", "document.pdf");
    }
