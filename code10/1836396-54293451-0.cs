    public IActionResult Index(string methodParam)
        {
           List<Menu> menu = new JavaScriptSerializer().Deserialize<Menu>(methodParam);
           foreach(Menu item in menu)
            {
                string des = item.Week + item.Year;
            }
            return View();
        }
