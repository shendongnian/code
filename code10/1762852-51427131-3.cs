        public ActionResult Details()
        {
            ...//prepare your person viewModel
            var result = new WebClient().DownloadString("url");
            var stats = JsonConvert.DeserializeObject<YourViewModel>(result);
            //you have 2 options to return data
            yourPersonModel.Stats=stats ; //<== you have to change PersonViewModel
            //or ViewBag.Stats=stats; 
            return View(yourPersonModel);
        }
