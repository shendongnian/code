    [HttpPost]
    public ActionResult Gerar(List<SongVm> songs)
    {
        // Simply returning the data with a message property as well
        return Json(new { messge ="success", data = songs });
    }
