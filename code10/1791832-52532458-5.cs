    [HttpPost]
    public JsonResult GetListOfServices(int[] CheckedItems)
    {
        Console.WriteLine(CheckedItems);
        return Json(new { message= "OK" });
    }
