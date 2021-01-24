    foreach(var menuSKU in iMenuSKUList)
                {
    
                        var menu = new IMenuSKU();
                        menu=iMenuList.Where(a => a.Id == menuSKU.Id).ToList()[0];
                        var menuSpecs=new List<IMenuMapping>() ;
                        menuSpecs= iMenuCompleteSKUList.Where(a => a.Id == menuSKU.Id ).ToList();
                        var media = new List<IMenuMedia>();
                        media = iMediaList.Where(a => a.Id == menuSKU.Id).ToList();
                        menu.MenuMappings = null;
                        menu.MenuMappings = menuSpecs;
                        menu.MenuMedias = null;
                        menu.MenuMedias = media;
       // issue has been resolved by creating new instance of object and reassigning it's properties with values as below and finally storing it in list.
                        var finalList = new IMenuSKU
                            {
                                MenuMappings = menu.MenuMappings,
                                MenuMedias  = menu.MenuMedias,
                               //bind remaining properties here
                            };					
    						              
                  finalMenuList.Add(finalList);
    			  
                }
