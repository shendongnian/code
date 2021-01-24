            public IActionResult Index()
        {
            var pageViewModel = new List<DataViewModel>()
            {
                new DataViewModel()
                {
                    Title="First data tab",
                    Data=new string []{"Item 1","Item 2","Item 3"}
                },
                new DataViewModel()
                {
                    Title="Second data tab",
                    Data=new string []{"Item 1","Item 2","Item 3"}
                }
            };
            return View(pageViewModel);
        }
