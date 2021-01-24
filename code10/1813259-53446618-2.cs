        [HttpGet]
        public ActionResult<HotelList> Get()
        {
            return _modelManager.ReturnQuery();
        }
