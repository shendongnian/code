    public IActionResult Index()
    {
        var mhsw = _context.Mahasiswas.OrderByDescending(m => m.Id).ToList();
        return View(mhsw);
    }
