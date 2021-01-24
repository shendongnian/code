     public ActionResult Index()
     {
        List<PieSeriesData> pieData = new List<PieSeriesData>();
        pieData.Add(new PieSeriesData { Name = "FireFox", Y = 45.0 });
        pieData.Add(new PieSeriesData { Name = "IE", Y = 26.8 });
        pieData.Add(new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true });
        pieData.Add(new PieSeriesData { Name = "Safari", Y = 8.5 });
        pieData.Add(new PieSeriesData { Name = "Opera", Y = 6.2 });
        pieData.Add(new PieSeriesData { Name = "Others", Y = 0.7 });
 
        //// Add additional data fields to the first PieSeriesData object.
        pieData[0].CustomFields.Add("expected", 37);
        pieData[0].CustomFields.Add("result", "success!");
        ViewData["pieData"] = pieData;
        return View();
    }
