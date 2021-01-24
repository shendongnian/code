    [HttpPost]
            public IActionResult Remove(int[] employeeIds)
            {                   
                if (repo.RemoveEmployee(employeeIds) == false)
                {
                    return Redirect("/Employee/Remove");
                }
                else
                {
                    return Redirect("/Employee");
                }
            }
