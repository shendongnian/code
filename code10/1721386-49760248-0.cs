    [KnownType(typeof(DeleteAPI.Models.TaskModel))]
    public class StudentModel
    {
        public int DeveloperID { get; set; }
        public int ProjectID { get; set; }
        public string WorkDate { get; set; }
        public Nullable<int> WorkingHours { get; set; }
        public Nullable<int> Overtime { get; set; }
        public string Descriptions { get; set; }
    }
