     public ActionResult Test()
            {
                  MyData = new Data();
                  MyData.One = 1;
                  ViewData["someData"]=MyData;
                  return View();
            }
