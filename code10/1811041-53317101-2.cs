    public IActionResult test(string type, string value)
            {
                int? count = GetCount(type, value);
                return View(count);
            }
