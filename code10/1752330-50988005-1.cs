        [HttpPost("info"), Authorize, Role("boxer")]
        public async Task<IActionResult> EditProfile([FromBody]BoxerProfileInfoEditModel model)
        {
            // do one thing...
        }
        [HttpPost("info"), Authorize, Role("manager", "promoter")]
        public async Task<IActionResult> EditProfile([FromBody]ManagerProfileInfoEditModel model)
        {
            // do another thing...
        }
