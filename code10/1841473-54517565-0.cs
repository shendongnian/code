        [HttpPost]
        public async Task<IActionResult> GetRaceOptions(RaceViewModel race)
        {
           //save options from RaceViewModel
        
           //get old options + newly added options
        
           var viewModel = old + newly added data
           return PartialView("RaceOptions", viewModel);
        }
