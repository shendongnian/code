        [Table(Name = "TblDepartment")]
        public class TblDepartment
        {
            [Key]
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }
