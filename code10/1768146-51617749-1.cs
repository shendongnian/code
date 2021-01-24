    public IActionResult SpinText(string Body)
    {
        SpinningResult spinningResult = new SpinningResult();
        spinningResult.Spintext = "This is the result text";
        return Json(spinningResult);
    }
