     public async Task<ActionResult> Index()
            {
                ApiClient api = new ApiClient("http://localhost:43674/ApiCore");
                var result = await api.GetAsync();
    
                RegulationViewModel viewModel = new RegulationViewModel
                {
                    ConnectedToRoadMap = result.ConnectedToRoadMap,
                    Decided = result.Decided,
                    Enforced = result.Enforced,
                    Id = result.Id,
                    Paragraph = result.Paragraph,
                    Pdf = Convert.ToBase64String(result.Pdf),
                    Published = result.Published,
                    Region = result.Region,
                    StructuredInfo = result.StructuredInfo,
                    Title = result.Title,
                    ValidThru = result.ValidThru
                };
    
                return View(viewModel);
            }
