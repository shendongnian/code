	[HttpPost]
	public IActionResult Post([FromBody]CreateDoctorInput createDoctorInput) {
		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}
		//do something
	}
