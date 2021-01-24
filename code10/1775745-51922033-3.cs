    public class Employee
    {
        StringBuilder sb = null;
        public Employee(): this("", "") { }
        public Employee(string Firstname, string Lastname)
        {
            this.sb = new StringBuilder();
            this.Subordinates = new List<Employee>();
            this.FirstName = Firstname;
            this.LastName = Lastname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Employee> Subordinates { get; set; }
        public string GetDirectSubordinates()
        {
            if (this.Subordinates == null) return string.Empty;
            return string.Join(Environment.NewLine, Subordinates
                         .OrderBy(s => s.LastName).ThenBy(s => s.FirstName)
                         .Select(se => '\t' + se.ToString()));
        }
        public string GetAllSubordinates()
        {
            sb.Append(this.ToString() + " Subordinates:" + Environment.NewLine);
            return GetSubordinateList(1);
        }
        private string GetSubordinateList(int SubLevel)
        {
            foreach (Employee Subordinate in this.Subordinates.OrderBy(sb => sb.FirstName).ThenBy(sb => sb.LastName))
            {
                sb.Append(new string('\t', SubLevel) + ((SubLevel == 1) ? "• " : "– ") + Subordinate.ToString() + Environment.NewLine);
                if (Subordinate.Subordinates != null && Subordinate.Subordinates.Count > 0)
                {
                    sb.Append(Subordinate.GetSubordinateList(SubLevel + 1) + Environment.NewLine);
                }
            }
            string result = sb.ToString();
            sb.Clear();
            return result;
        }
        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
