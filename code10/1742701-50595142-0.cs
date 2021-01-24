	[HttpPost]
	public JsonResult DoesGbSNumberExist(int? gbsNumber)
	{
		using (var db = new ADVWKSPEntities())
		{
			return (gbsNumber == null) ? Json(false) : Json(!db.CRMTItems.Any(i => i.GbsNumber == gbsNumber));
		}
	}
