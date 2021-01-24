    public IActionResult MyView(Guid? id, FormData optionalFormData = null)
    {
        if (!optionalFormData.IsNullOrDefault())
        {
            return View(optionalFormData);
        }
        return View(_context.Data.FirstOrDefault(x => x.Id == id.Value));
    }
