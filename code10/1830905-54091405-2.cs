    class PostData
    {
        public string[] userRoles { get; set; }
        public string email { get; set; }
    }
    [HttpPost]
    public async Task<IActionResult> SaveUserRoles([FromBody]PostData postData)
    {
        return Ok();
    }
