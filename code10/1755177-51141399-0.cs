           public ActionResult Index()
            {
                var input = new InputModel();
                input.Type = input.FillType(input.Type);
    
                return View(input);
            }
    
            [HttpPost]
            public ActionResult Index(InputModel input)
            {
                input.FileType = input.ValueConvert();
                input.FileFind();
                TempData["model"] = input
                return View("Result", input);
            }
    
            public ActionResult Result(InputModel input)
            {
                return View(input);
            }
    
    
            [HttpPost]
            public void Result()
            {
                InputModel model = new InputModel();
                model = (InputModel)TempData["model"];
                model.ExportToExcel();
            }
