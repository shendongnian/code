    public LastNameRule : IRule
    {
        public bool IsApproved(Assignment assignment) //Interface method
        {
            if (assignment.Person.Lastname == "Johnsson")
            {
                return false;
            }
            return true;
        }
    }
    public GenderRule : IRule
    {
        public bool IsApproved(Assignment assignment) //Interface method
        {
            if (assignment.Person.Gender== Gender.Female)
            {
                return false;
            }
            return true;
        }
    }
