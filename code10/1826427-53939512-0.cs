    var matches = new Dictionary<int, List<int>>();
    
    var employees = employeeSkills.ToLookup(emp => emp.EMP_ID, skill => skill.SKILL_ID);
    var jobs = skillsRequired.GroupBy(skill => skill.JOB_ID, skill => skill.SKILL_ID);
    
    foreach (var job in jobs)
    {
        var capableEmployees = new List<int>();
    
        foreach (var employee in employees)
        {
            bool isCapable = true;
    
            foreach (int requiredSkill in job)
            {
                bool hasRequiredSkill = false;
    
                foreach (int skill in employee)
                {
                    if (skill == requiredSkill)
                    {
                        hasRequiredSkill = true;
                        break;
                    }
                }
    
                if (!hasRequiredSkill)
                {
                    isCapable = false;
                    break;
                }
            }
    
            if (isCapable)
            {
                capableEmployees.Add(employee.Key);
            }
        }
    
        matches.Add(job.Key, capableEmployees);
    }
