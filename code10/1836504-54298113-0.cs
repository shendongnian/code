    [Serializable]
    public class AdsPageViewModel
    {
      public List<CategorySummaryViewModel> Categories { get; set; } = new List<CategorySummaryViewModel>();
      public List<AdSummaryViewModel> Ads { get; set; } = new List<AdSummaryViewModel>();
    }
    
    public ActionResult Index()
    {
      var mymodel = new AdsPageViewModel
      {
        Categories = db.Categories.Select(x=> new CategorySummaryViewModel
        {
          Id = x.Id,
          Name = x.Name // Append other fields if necessary for the view.
        }).ToList(),
        Ads = db.Ads.Select(x => new AdSummaryViewModel
        {
          Id = x.Id,
          Name = x.Name
        }).ToList()
      };
      return View(mymodel);           
    }
