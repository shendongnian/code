    [HttpPost]
            public string Login(ExternalLogin login)
            {
                var userToken = login.access_token;
                var empId = login.user_id;
                var emp = _context.Employees.Where(x => x.Id== empId).FirstOrDefault();
                if (UserExists(empId) == true)
                {
                    if (empId != null)
                    {
                        HttpContext.Session.SetString("username", empId);
                        HttpContext.Session.SetString("empId", emp.EmployeeId.ToString());
                        HttpContext.Session.SetString("user_role", IsInRole(emp.Id));
                        HttpContext.Session.SetString("name", emp.Fullname);
                    }
                    return "Success";
                }
                return "Failed";
            }
