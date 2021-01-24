    class ProfileCourse
    {
        public int ProfileId {get; set;}
        public int CourseId {get; set;}
    }
    var ProfileIdCourseIdCombinations = db.Profiles
        .SelectMany(profile => profile.CourseIds.Split(',", StringSplitOptions.RemoveEmptyEntries),
        (profile, splitCourseId) => new ProfileCourse
        {
             ProfileId = profile.Id,
             CourseId = splitCourseId,
        });
