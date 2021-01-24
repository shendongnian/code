     public ActionResult CourseEnquiry(string course) // parameter variables are camel-case
    {
        var model = Mapper.Map<CourseEnquiryVM>(CurrentContent);
    
        if(!string.IsNullOrWhiteSpace(course))
            model.Course = course;
        return model;
     }
