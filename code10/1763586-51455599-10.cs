    [HttpPost]
        public ActionResult AddVolunteer(VolunteerInfo viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddVolunteer", viewModel);
            }
    
            var volunteer = new VolunteerInfo()
            {
                Name = viewModel.Name,
                BirthdayDateTime = viewModel.BirthdayDateTime,
                Address = viewModel.Address,
                PhoneNumber = viewModel.PhoneNumber,
                EmailAddress = viewModel.EmailAddress,
                OccasionsID = viewModel.OccasionsID,
                DonationForWhom = viewModel.DonationForWhom
            };
            if (!string.IsNullOrEmpty(volunteer.DonationForWhom))
            {
                _context.VolunteerInfos.Add(volunteer);
                _context.SaveChanges();
            }
    
            return View(viewModel);
    
        }
