    public ActionResult register(text2give reg)
    {
        string body = reg.body;
        try
        {
            var tester = body.Split(',')                            // Split the initial value into items
                             .Select(i => i.Split(' '))             // Split each item into elements
                             .Where(s => s.Length == 2)             // Take only those that have 2 items
                             .GroupBy(s => s[0])                    // Group by the key
                             .Where(g => g.Count() == 1)            // Remove all those that have a duplicate key
                             .SelectMany(g => g)                    // Ungroup them again
                             .ToDictionary(s => s[0], 
                                           s => float.Parse(s[1])); // Create a dictionary where the first item is the key and the second is the parsed float
            var total = tester.Sum(s => s.Value);
            ViewBag.total = total;
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        return View(reg);
    }
