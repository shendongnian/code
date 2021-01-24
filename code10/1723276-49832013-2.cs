	var userInfo = new Dictionary<string, object>
	{
		{"id", userProfile.UserId},
		{"email", userProfile.Email},
		{"name", userProfile.Name}
	};
	if (fields.Contains("picture_url"))
	{
		// error in this line
		userInfo.Add("picture_url", "path");
	}
    return Ok(userInfo);
