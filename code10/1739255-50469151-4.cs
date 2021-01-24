    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var uploadPath = Path.Combine(hostingEnv.WebRootPath, "uploadsfolder");
        using (var fileStream = new FileStream(Path.Combine(uploadPath, file.FileName), FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return RedirectToAction("Index");
     }
