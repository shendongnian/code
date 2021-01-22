      var list = new SelectList(new []
                                              {
                                                  new {ID="1",Name="name1"},
                                                  new{ID="2",Name="name2"},
                                                  new{ID="3",Name="name3"},
                                              },
                                "ID","Name",1);
                ViewData["list"]=list;
                return View();
