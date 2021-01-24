    [HttpGet("ProfilePic")]
    public async Task<IActionResult> GetProfilePicture()
    {
        var user = await GetUserFromBearerToken();
    
        Stream imageStream = await _fileService.ReadObjectData(MediaFolder.Profiles, user.ProfileImageFileName);
    
        Response.Headers.Add("Content-Disposition", new ContentDisposition
        {
            FileName = "Image.jpg",
            Inline = true // false = prompt the user for downloading; true = browser to try to show the file inline
        }.ToString());
    
        return File(imageStream, "image/jpeg");
    }
