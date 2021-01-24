    if (ModelState.IsValid)
    {
        EmployeeAbsenceValidator validator = new EmployeeAbsenceValidator();
        ValidationResult result = validator.Validate(employeeAbsence);
        if (!result.IsValid)
        {
            return this.View( employeeAbsence );
        }
        else
        {
            _context.Add(employeeAbsence);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Employees");
        }
    }
