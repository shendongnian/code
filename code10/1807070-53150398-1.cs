       [HttpGet("GetUniversities")]
       public async Task<ServiceResult> GetUniversities()
       {
           return await universityService.GetUniversities();
       }
       [HttpGet("GetUniversityStatues")]
       public async Task<ServiceResult> GetUniversityStatues()
       {
           return await universityService.GetUniversityStatues();
       }
