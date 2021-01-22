    try
    {
        DateTime date = Convert.ToDateTime("abc");
    }
    catch(Exception ex)
    {
       ViewData["Error"] = ex.Message;
    }
    return View();
