    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Show(int id, bool? asHtml)
    {
        var result = Stationery.Load(id);
        if (asHtml.HasValue && asHtml.Value)
            return Content(result.GetHtml());
        else
            return new XmlResult(result);
    }
