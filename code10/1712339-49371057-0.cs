    public ActionResult register(text2give reg)
    {
        string body = reg.body;
        try
        {
            var items = body.Split(',');
            var splitItems = items.Select(i => i.Split(' ')).ToList();
            var itemsWithTwoValues = splitItems.Where(s => s.Length == 2);
            var uniqueItems = itemsWithTwoValues.GroupBy(s => s[0])
                                                .Where(g => g.Count() == 1)
                                                .SelectMany(g => g);
            var tester = uniqueItems.ToDictionary(s => s[0], s => float.Parse(s[1]));
            var total = tester.Sum(s => s.Value);
            ViewBag.total = total;
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        return View(reg);
    }
