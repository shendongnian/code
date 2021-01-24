    public PartialViewResult MainMenu()
    {
       List<YourApp.Models.Menu> menuItems = new List<YourApp.Models.Menu>();
    
       /* Add your menus item here */
    
       menuItems.Add(
            new YourApp.Models.Menu() {
                Title = "Level 1",
                SubItems = new List<YourApp.Models.Menu>() {
                    new YourApp.Models.Menu() {
                        Title = "Level 2",
                        SubItems = new List<YourApp.Models.Menu>() {
                            new YourApp.Models.Menu() {
                                Title = "Level 3",
                                Url = Url.Action("SampleAction", "SampleController")
                            }
                        }
                    }
                }
            }
       );
       return PartialView("~/Views/Shared/MainMenu", menuItems);
    }
    
