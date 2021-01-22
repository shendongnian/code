    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create([Bind(Exclude = "Id")] Artist artist, [Bind(Prefix = "Contact")] Contact contact, [Bind(Prefix = "Country")] Country country, [Bind(Prefix = "ContactRelationship")] ContactRelationship contactRelationship)
    {
        ViewData["Countries"] = new SelectList(new CountryService(_msw).ListCountries().OrderBy(c => c.Name), "ID", "Name");
        ViewData["ContactRelationships"] = new SelectList(new ContactRelationshipService(_msw).ListContactRelationships().OrderBy(c => c.ID), "ID", "Description");
    
        country = _countryService.GetCountryById(country.ID);
        contact.Country = country;
        contactRelationship = _contactRelationshipService.GetContactRelationship(contactRelationship.ID);
        contact.ContactRelationship = contactRelationship;
        if(_contactService.CreateContact(contact)){
            artist.Contact = contact;
            if (_service.CreateArtist(artist))
                return RedirectToAction("Index");        
        }
        return View("Create");
    }
