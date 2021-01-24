    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<EmployeeSkills> employeeSkills = new List<EmployeeSkills>() {
                    new EmployeeSkills() { EMP_SKILL_ID = 1, EMP_ID = 1, SKILL_ID = 1},
                    new EmployeeSkills() { EMP_SKILL_ID = 2, EMP_ID = 1, SKILL_ID = 2},
                    new EmployeeSkills() { EMP_SKILL_ID = 3, EMP_ID = 1, SKILL_ID = 3},
                    new EmployeeSkills() { EMP_SKILL_ID = 4, EMP_ID = 2, SKILL_ID = 1},
                    new EmployeeSkills() { EMP_SKILL_ID = 5, EMP_ID = 2, SKILL_ID = 2},
                    new EmployeeSkills() { EMP_SKILL_ID = 6, EMP_ID = 2, SKILL_ID = 4}
                };
                List<SkillsRequired> skillsRequired = new List<SkillsRequired>() {
                    new SkillsRequired() { SKILL_REQ_ID = 1, JOB_ID = 1, SKILL_ID = 1},
                    new SkillsRequired() { SKILL_REQ_ID = 2, JOB_ID = 1, SKILL_ID = 2},
                    new SkillsRequired() { SKILL_REQ_ID = 3, JOB_ID = 1, SKILL_ID = 3},
                    new SkillsRequired() { SKILL_REQ_ID = 4, JOB_ID = 2, SKILL_ID = 1},
                    new SkillsRequired() { SKILL_REQ_ID = 5, JOB_ID = 2, SKILL_ID = 2},
                    new SkillsRequired() { SKILL_REQ_ID = 6, JOB_ID = 2, SKILL_ID = 4},
                    new SkillsRequired() { SKILL_REQ_ID = 7, JOB_ID = 2, SKILL_ID = 5}
                };
                var skills_employees = (from s in skillsRequired
                                        join e in employeeSkills on s.SKILL_ID equals e.SKILL_ID
                                        select new { skill_required_id = s.SKILL_REQ_ID, job_id = s.JOB_ID, skill_id = s.SKILL_ID, emp_skill_id = e.EMP_SKILL_ID, emp_id = e.EMP_ID }
                                        ).ToList();
                Dictionary<int, List<int>> job_skills = skillsRequired.GroupBy(x => x.JOB_ID, y => y.SKILL_ID)
                    .ToDictionary(x => x.Key, y => y.ToList());
                var groups = skills_employees.GroupBy(x => new { employee = x.emp_id, job_id = x.job_id }).Select(x => new { employee = x.Key.employee, job_id = x.Key.job_id, skills = x.Select(y => y.skill_id).ToList() }).ToList();
                var results = groups.Select(x => new { employee_id = x.employee, job_id = x.job_id, qualifed = job_skills[x.job_id].All(y => x.skills.Contains(y)) ? "qualified" : "not qualified" }).ToList(); 
            }
        }
        public class EmployeeSkills
        {
            public int EMP_SKILL_ID { get; set; }
            public int EMP_ID { get; set; }
            public int SKILL_ID { get; set; }
        }
        public class SkillsRequired
        {
            public int SKILL_REQ_ID { get; set; }
            public int JOB_ID { get; set; }
            public int SKILL_ID { get; set; }
        }
    }
