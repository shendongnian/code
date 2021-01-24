    [HttpPost("addtoblacklist")]
        public IActionResult AddToBlackList([FromBody] AddToBlackListModel creationModel)
        {
            // 
            if (!int.TryParse(User.Identity.Name, out var doctorId))
            {
                return BadRequest(new { message = "Wrong claims" });
            }
            var status = _doctorService.AddToBlackList(creationModel.id, doctorId);
            return status ? (IActionResult)Ok() : BadRequest();
        }
