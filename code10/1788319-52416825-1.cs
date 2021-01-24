    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Item item,IFormFile image)
    {
        if (ModelState.IsValid)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileSteam);
                }
                item.Image = fileName;
            }
            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }
