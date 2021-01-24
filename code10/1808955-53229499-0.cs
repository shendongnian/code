    	public ActionResult ViewData(int id)
		{
			ViewBag.CountyList = new SelectList(GetCountyList(), "Value", "Text");
			ViewBag.SectorList = new SelectList(GetSectorList(), "Value", "Text");
			ViewBag.SpecialismList = new SelectList(GetSpecialisationList(), "Value", "Text");
			var viewModel = new AgencyAll {
				Agency = _db.Agencies.FirstOrDefault(x => x.id == id),
				AgencySector = _db.AgencySectors.FirstOrDefault(),
				AgencyExpertise = _db.AgencyExpertises.FirstOrDefatul()
			}
			return View(viewModel);
		}
