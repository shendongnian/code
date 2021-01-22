    public OvertimeRule : IRule
    {
        public bool IsApproved(Assignment assignment) //Interface method
        {
            if (assignment.Person.Timesheet >= 40)
            {
                return false;
            }
            return true;
        }
    }
    public InternRule : IRule
    {
        public bool IsApproved(Assignment assignment) //Interface method
        {
            if (assignment.Person.Title == "Intern")
            {
                return false;
            }
            return true;
        }
    }
