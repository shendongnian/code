	[ResponseType(typeof(Apartment[]))]
	public IHttpActionResult GetApartments(Guid houseId)
	{
		var apartments = db.Apartments.Where(user => user.HouseId == houseId).ToList();
		if (!apartments.Any())
		{
			return NotFound();
		}
		return Ok(apartments);
	}
