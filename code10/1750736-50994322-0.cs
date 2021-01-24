    public IActionResult SaveGridState(string options, int gridID)
		{
			try
			{
				UserStore ustore = new UserStore(_settings);
				HttpContext.Session.LoadAsync();
				uint user_id = (uint)HttpContext.Session.GetInt32("UserID");
				options = options.Replace("'", @"\'");
				bool success = ustore.SaveGridState(user_id, gridID, options);
				return Ok(new { Result = success, Message = success ? _localizer["GridSaveSuccess"].Value : _localizer["GridSaveFail"].Value });
			}
			catch (Exception ex)
			{
				return BadRequest(new { Result = false, Message = _localizer["GridSaveFail"].Value });
			}
		}
