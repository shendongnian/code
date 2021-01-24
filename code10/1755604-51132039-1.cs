    public async Task<JsonResult> 
    Create([Bind("Department_Id,Title,Task,Description,Department_Status")] 
    Department department)
        {
           
            if (ModelState.IsValid)
            {             
              
                _genericRepository.Add(department);
                await _genericRepository.SaveChangesAsync();
                return Json(department);
            }
            return Json(department);
        }`
