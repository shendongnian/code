    public ActionResult Index()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://xxx.azurewebsites.net/joeyAPI/api/");
            //HTTP GET
            var responseTask = client.GetAsync("values");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                var students = readTask.Result;
                ViewBag.Message = students.ToString();
             }
        }
        return View();
    }
