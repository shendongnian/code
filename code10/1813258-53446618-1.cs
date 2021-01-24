        [HttpPost]
        public IActionResult Index(SearchRoomsModel model)
        {
            string _query = string.Format("{0},{1} 12:00,{2} 12:00,{3},{4}", model.Location, model.CheckIn, model.CheckOut, model.NumAdults, model.NumChild);
            _modelManager.SaveQuery(_query);
            return RedirectToAction("Hotel");
        }
 
