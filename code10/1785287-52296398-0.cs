    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("[action]")]
    public IActionResult EditEmployee(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _repo.edit(employee);
            _repo.Save();
            return Json(new { Message="Update was successful!"});
        }   
       return BadRequest(new { Message="Something went wrong!"});
    }
