            [HttpPost]
            public IHttpActionResult PostPersonalDetails([FromBody] PersonalDetails
    personaldetails)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                db.PersonalDetails.Add(personaldetails);
                db.SaveChanges();
    
                return Ok(personaldetails);
            }
