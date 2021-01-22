    public ActionResult AddToFavourites(string url)
    {
        url = Encoding.Default.GetString(Convert.FromBase64String(url));
        return View(url);
    }
