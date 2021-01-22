    class EmpComp : IComparer<Employee>
    {
        string fieldName;
        public EmpComp(string fieldName)
        {
            this.fieldName = fieldName;
        }
        public int Compare(Employee x, Employee y)
        {
            // compare x.fieldName and y.fieldName
        }
    }
