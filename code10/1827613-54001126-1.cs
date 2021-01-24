    // GET method
    [HttpGet]
    [Route("api/CourseRegistrations/{id}"), Name = "GetCourseRegistrationById")]
    [ResponseType(typeof(CourseRegistration))]
    public IHttpActionResult GetCourseRegistration(int id)
    {
        // do something
    }
    // POST method
    [HttpPost]
    [Route("api/CourseRegistrations")]
    public IHttpActionResult PostCourseRegistration(CourseRegistration courseRegistration)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }
        db.CourseRegistrations.Add(courseRegistration);
        db.SaveChanges();
        // replace 'DefaultApi' with route name for redirect to GET method
        return CreatedAtRoute("GetCourseRegistrationById", new { id = courseRegistration.course_id }, courseRegistration);
    }
