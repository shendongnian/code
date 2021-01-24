        protected void Page_Load(object sender, EventArgs e)
    {
        string filename = "";
        if (Request.Headers.AllKeys.Contains("CF-IPCountry"))
        {
            string countrycode = Request.Headers["CF-IPCountry"].ToString();
            if (Directory.Exists(Server.MapPath("~/img/" + countrycode)))
            {
                string[] files = Directory.GetFiles(Server.MapPath("~/img/" + countrycode + "/"), "*.jpg");
                Random _r = new Random();
                int randomimage = _r.Next(files.Length);
                filename = "/img/" + countrycode + "/" + Path.GetFileName(files[randomimage]);
            }
       
        }
        if (filename.Length == 0)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/img/none/"), "*.jpg");
            Random _r = new Random();
            int randomimage = _r.Next(files.Length);
            filename = "/img/none/" + Path.GetFileName(files[randomimage]);
        }
        Literal1.Text = filename;
    }
