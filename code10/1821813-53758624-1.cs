        [HttpPost]
        public IActionResult Post([ModelBinder(typeof(EmbededServerDataBinder<Ow_ServerModel>))] Ow_ServerModel ServerData)
        {
            return Ok("Working");
        }
