        public ActionResult Stats()
        {
            var result = new WebClient().DownloadString("url");
            var yourViewModel = JsonConvert.DeserializeObject<YourViewModel>(result);
            return PartialView(yourViewModel);
        }
