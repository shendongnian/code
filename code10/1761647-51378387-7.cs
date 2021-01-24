    public async Task<ActionResult<FileContentResult>> GetFile(Guid fileId)
    {
        if (!this.UserHasNoAccessToFile(fileId))
            return Unauthorized();
        var bytes = await System.IO.File.ReadAllBytesAsync("some path");
        return File(bytes, "contentType");
    }
