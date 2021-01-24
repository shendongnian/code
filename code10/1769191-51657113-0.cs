    //ASP.NET Core
    [HttpPost]
    public IActionResult UploadJSON([FromBody] IList<PlayList> playList)
    {
        var inputBody = jsoninput;
        // Writing JSON object content into a file....
        return RedirectToAction("Index");
    }
