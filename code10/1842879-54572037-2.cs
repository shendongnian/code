    [HttpGet("school/{schoolId}/departments")]
    public async Task<IActionResult> GetDepartmentsFromSchool(int schoolId)
    {
        var departments = await _departmentSchoolRepository
            .GetAllDepartmentBySchoolIdAsync(schoolId);
        if (departments.Any())
        {
            return Ok(departments)
        }
        return NotFound();
    }
