    //First Page Load Method In Initialize Model Because Cost Is Initialize
            public IActionResult Index()
            {
                
                return View(new Test());
            }
            //This Is Edit Method 
            public IActionResult Edit(float id)
            {
                Test t = new Test()
                {
                    Cost = id
                };
                return View("Index",t);
            }
            //First Page Post Method
            [HttpPost]
            public IActionResult Index(Test model)
            {
                return View(model);
            }
