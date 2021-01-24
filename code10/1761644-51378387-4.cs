    [HttpGet]
    [Authorize("FileAccess")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public ActionResult<FileContentResult> GetFile(Guid fileId)
    {
        if (!this.UserHasNoAccessToFile(fileId))
            return Unauthorized();
        return File(...)
    }
