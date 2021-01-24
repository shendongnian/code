    public ActionResult DetailShow(int id)
    {
        string cokvalue = ControllerContext.RouteData.Values["id"].ToString();
        HttpCookie cok = Request.Cookies["last viewed"];
        List<string> cookielist = new List<string>();
        cookielist.Add(cokvalue);
        if (cok == null)
        {
            var serialize = JsonConvert.SerializeObject(cookielist);
            cok = new HttpCookie("last viewed");
            cok.Values["last visited"] = serialize;
        }
        else
        {                
            cookielist.InsertRange(0,JsonConvert.DeserializeObject<List<string>>(cok.Values["last visited"]));                                
            var serialize = JsonConvert.SerializeObject(cookielist);                
            cok.Values["last visited"] = serialize;
        }
        cok.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(cok);
        HttpCookie mycookie = new HttpCookie("Product");
        mycookie.Values["asd"] = cokvalue;
        mycookie.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(mycookie);
        var product = gelistirmeEntities.Product.Where(p => p.Product_ID == id).FirstOrDefault();
        return View(product);
    }
