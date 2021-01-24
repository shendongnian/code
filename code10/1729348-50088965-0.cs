    public ActionResult Timeline()
    {
        var articleQuery = from a in artDb.dbArticle
                           select new { a.Date, a.StockPriceClose };
        List<DataPoint> dataPoints = new List<DataPoint>();
        foreach (var item in articleQuery)
        {
            double stockPriceClose = double.Parse(item.StockPriceClose.ToString());
            DateTime date = Convert.ToDateTime(item.Date);
            **
            var dataPoint =  new DataPoint(date, stockPriceClose);
            dataPoints.add(dataPoint )
            **
        }             
        ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
        return View();
    }
