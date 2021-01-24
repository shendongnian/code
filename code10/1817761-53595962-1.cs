    [HttpPost]
    public ActionResult AddtoCart(int sum)
    {
        var viewModel = new MyViewModel
        {
            SumVM = SumVM + sum
        };
        return View(viewModel);
    }
