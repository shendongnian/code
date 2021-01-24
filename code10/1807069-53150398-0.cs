        [HttpGet]
        public async Task<ServiceResult> GetUniversities()
        {
            return await universityService.GetUniversities();
        }
