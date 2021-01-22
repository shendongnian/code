        namespace DoctaJonez.TestingBrace
        {
            public partial class Menu //: IActiveRecord 
            { 
                public int ID { get; set; } 
                public int CategoryID { get; set; } 
                public bool Visible { get; set; } 
                public int PageID { get; set; } 
                public IQueryable<WebPage> WebPages { get; set; } 
            } 
        
            public partial class WebPage //: IActiveRecord 
            { public int ID { get; set; } public string Roles { get; set; } }
        
            public static class Launcher
            {
                /// <summary>
                /// The Main entry point of the program.
                /// </summary>
                static void Main(string[] args)
                {
                    Menu myMenu1 = new Menu
                    {
                        ID = 1,
                        CategoryID = 1,
                        PageID = 1,
                        Visible = true,
                        WebPages = new List<WebPage>()
                        {
                            new WebPage { ID = 1, Roles = "Role1" },
                            new WebPage { ID = 1, Roles = "Role2" },
                            new WebPage { ID = 1, Roles = "Role3" },
                        }.AsQueryable()
                    };
        
                    Menu myMenu2 = new Menu
                    {
                        ID = 1,
                        CategoryID = 1,
                        PageID = 1,
                        Visible = true,
                        WebPages = new List<WebPage>()
                        {
                            new WebPage { ID = 1, Roles = "Role3" },
                            new WebPage { ID = 1, Roles = "Role4" },
                            new WebPage { ID = 1, Roles = "Role5" },
                        }.AsQueryable()
                    };
        
                    Menu myMenu3 = new Menu
                    {
                        ID = 1,
                        CategoryID = 1,
                        PageID = 1,
                        Visible = true,
                        WebPages = new List<WebPage>()
                        {
                            new WebPage { ID = 1, Roles = "Role5" },
                            new WebPage { ID = 1, Roles = "Role6" },
                            new WebPage { ID = 1, Roles = "Role7" },
                        }.AsQueryable()
                    };
        
                    List<Menu> menus = new List<Menu>() { myMenu1, myMenu2, myMenu3 };
        
                    string roleToSearchFor = "Role3";
        
                    var allCategories = menus.Where(menu => menu.CategoryID == 1 && menu.Visible && menu.WebPages.Any(webPage => webPage.Roles.Contains(roleToSearchFor))).ToList();
        
                    return;
                }
            }
