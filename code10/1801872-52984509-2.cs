    [HttpGet("GetUsers")]
    [Authorize(Roles = "admin")]
        public ActionResult GetUsers()
        {
            var users = _authRepository.GetUsers();
            return Ok(users);
        }
