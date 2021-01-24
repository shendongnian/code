    public IActionResult Cheese(string fname, string lname)
    {
        @ViewData["Data"]=$"Hello, {fname ?? "Dr."} {lname ?? "Cheeseburger"}";
        return View();
    }
