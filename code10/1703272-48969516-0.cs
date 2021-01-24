     public async Task<IActionResult> Save(Gallery gallery, string tags) {
         
        if (tags != null)
        {
            gallery.Tags = ParseTags(tags);
        }
            
            
        _context.Galleries.Add(gallery);
        await _context.SaveChangesAsync();
        return RedirectToAction("UploadForm", "Gallery");
     }
