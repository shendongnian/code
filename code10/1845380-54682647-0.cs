    public ActionResult ShowProduct(int? id, Message message)
    {
        ViewBag.Message = message;
        return View("ShowProduct");
    }
