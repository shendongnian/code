            public IActionResult Index()
        {
            var pageViewModel = new List<DataViewModel>()
            {
                new DataViewModel()
                {
                    Title="First data tab",
                    Data=new List<Entity>()
                    {
                        new Entity()
                        {
                            Name="First item",
                            BriefDescription="My description",
                            Price=1000
                        },
                        new Entity()
                        {
                            Name="Second",
                            BriefDescription="My description",
                            Price=500
                        },
                        new Entity()
                        {
                            Name="Third",
                            BriefDescription="My description",
                            Price=1000
                        }
                    }
                },
                new DataViewModel()
                {
                    Title="Second data tab",
                    Data=new List<Entity>()
                    {
                        new Entity()
                        {
                            Name="First item",
                            BriefDescription="My description",
                            Price=1000
                        },
                        new Entity()
                        {
                            Name="Second",
                            BriefDescription="My description",
                            Price=500
                        },
                        new Entity()
                        {
                            Name="Third",
                            BriefDescription="My description",
                            Price=1000
                        }
                    }
                }
            };
            return View(pageViewModel);
        }
