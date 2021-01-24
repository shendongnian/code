            [HttpGet("", Name="Students"]
            public async Task<ServiceResult> GetStudents()
            {
                return await universityService.GetStudents();
            }
