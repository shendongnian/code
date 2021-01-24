	public IHttpActionResult Post([FromBody] string value)
	{
		int width = 0;
		Int32.TryParse(value, out width);
		HttpCookie deviceType = new HttpCookie("device-type");
		if (width < 768)
		{
			deviceType.Value = "mobile";
		}
		else
		{
			deviceType.Value = "non-mobile";
		}
		deviceType.Expires = DateTime.Now.AddMinutes(30);
		deviceType.Domain = Request.RequestUri.Host;
		deviceType.Path = "/";
		HttpContext.Current.Response.Cookies.Add(deviceType);
		return Ok();
	}
