    public partial class Role
    {
        public int Role_Id { get; set; }
        public int EmpID { get; set; }
        public bool Door_Unlock { get; set; }
        public bool Accounts { get; set; }
        public bool Bounds_Email { get; set; }
        public bool Salary_Privilege { get; set; }
        public bool Card_Acceptance { get; set; }
        public bool IsAdmin { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
