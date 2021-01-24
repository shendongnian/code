    It's not required to pass the method name with Http Verb
    
    You can use like this also.
    
            [HttpGet]
            public async Task<ServiceResult> GetUniversities()
            {
                return await universityService.GetUniversities();
            }
    
    But you want to change the method name or route. You can something like this.
    
            [HttpGet("", Name="Students"]
            public async Task<ServiceResult> GetStudents()
            {
                return await universityService.GetStudents();
            }
