        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("api/Tokens")]
        public IActionResult TestAuthorization()
        {
            return Ok("You're Authorized");
        }
