    [HttpGet("school/{schoolId}/departments")]
    public async Task<IActionResult> GetDepartmentsFromSchool(int schoolId)
    {
        var departments = await _departmentSchoolRepository.GetAllDepartmentBySchoolIdAsync();
        if (departments.Any())
        {
            return Ok(departments)
        }
        return NotFound();
    }
