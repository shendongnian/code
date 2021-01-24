    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Foo foo)
    {
        if (!ModelState.IsValid)
        {
          //error
        }
    }
