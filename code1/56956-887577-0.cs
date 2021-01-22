    public ActionResult Create( Person person,
                                [Bind(Prefix="Person.PersonDetails")]PersonDetails details,
                                [Bind(Prefix="Person.PersonDetails.ContactInformation")]ContactInformation[] info )
    {
          person.PersonDetails = details;
          person.PersonDetails.ContactInformation = info;
          ...
    }
