            [HttpPost]
            public ActionResult Index(FormCollection form)
            {
                private DbContextA db1 = new DbContextA();
                private DbContextB db2 = new DbContextB();
                string selStorageValue = form["StorageTypes"];
            // Assuming selStorageValue has some value.
                ViewBag.Productos = null;
                if (selStorageValue != null)
                {
                    if(selStorageValue.ToString()=="1"){
                        ViewBag.Productos=db1.Productos.ToList();
    
                    }
                    else if(selStorageValue.ToString()=="2"){
                        ViewBag.Productos=db2.Productos.ToList();
    
                    }
                }
                else{
                     ViewBag.Productos=db1.Productos.ToList();
    
                }
                return View(); //View must be binded
    
           }
