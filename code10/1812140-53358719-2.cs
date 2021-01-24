    public ActionResult GetHtmlForDropDown(string selection)
    {
        string html = ...; // Get the html depending on 'selection'
        return PartialView(html);
    }
